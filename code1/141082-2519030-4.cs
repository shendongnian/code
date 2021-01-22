    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Web.UI.WebControls;
    using System.ComponentModel;
    
    namespace cly.Web.CustomControls
    {
        public class clyGridView : GridView
        {
            private const string _virtualCountItem = "bg_vitemCount";
            private const string _sortColumn = "bg_sortColumn";
            private const string _sortDirection = "bg_sortDirection";
            private const string _currentPageIndex = "bg_pageIndex";
    
            public clyGridView ()
                : base()
            {
            }
    
            #region Custom Properties
            [Browsable(true), Category("NewDynamic")]
            [Description("Set the virtual item count for this grid")]
            public int VirtualItemCount
            {
                get
                {
                    if (ViewState[_virtualCountItem] == null)
                        ViewState[_virtualCountItem] = -1;
                    return Convert.ToInt32(ViewState[_virtualCountItem]);
                }
                set
                {
                    ViewState[_virtualCountItem] = value;
                }
            }        
    
            public string GridViewSortColumn
            {
                get
                {
                    if (ViewState[_sortColumn] == null)
                        ViewState[_sortColumn] = string.Empty;
                    return ViewState[_sortColumn].ToString();
                }
                set
                {
                    if (ViewState[_sortColumn] == null || !ViewState[_sortColumn].Equals(value))
                        GridViewSortDirection = SortDirection.Ascending;
                    ViewState[_sortColumn] = value;
                }
            }
    
            public SortDirection GridViewSortDirection
            {
                get
                {
                    if (ViewState[_sortDirection] == null)
                        ViewState[_sortDirection] = SortDirection.Ascending;
                    return (SortDirection)ViewState[_sortDirection];
                }
                set
                {
                    ViewState[_sortDirection] = value;
                }
            }
    
            private int CurrentPageIndex
            {
                get
                {
                    if (ViewState[_currentPageIndex] == null)
                        ViewState[_currentPageIndex] = 0;
                    return Convert.ToInt32(ViewState[_currentPageIndex]);
                }
                set
                {
                    ViewState[_currentPageIndex] = value;
                }
            }
    
            private bool CustomPaging
            {
                get { return (VirtualItemCount != -1); }
            }
            #endregion
    
            #region Overriding the parent methods
            public override object DataSource
            {
                get
                {
                    return base.DataSource;
                }
                set
                {
                    base.DataSource = value;
                    // store the page index so we don't lose it in the databind event
                    CurrentPageIndex = PageIndex;
                }
            }
    
            protected override void OnSorting(GridViewSortEventArgs e)
            {            
                //Store the direction to find out if next sort should be asc or desc
                SortDirection direction = SortDirection.Ascending;
                if (ViewState[_sortColumn] != null &&  (SortDirection)ViewState[_sortDirection] == SortDirection.Ascending)
                {
                    direction = SortDirection.Descending;
                }
                GridViewSortDirection = direction;
                GridViewSortColumn = e.SortExpression;
                base.OnSorting(e);
            }
    
            protected override void InitializePager(GridViewRow row, int columnSpan, PagedDataSource pagedDataSource)
            {
                // This method is called to initialise the pager on the grid. We intercepted this and override
                // the values of pagedDataSource to achieve the custom paging using the default pager supplied
                if (CustomPaging)
                {
                    pagedDataSource.VirtualCount = VirtualItemCount;
                    pagedDataSource.CurrentPageIndex = CurrentPageIndex;
                }
                base.InitializePager(row, columnSpan, pagedDataSource);
            }
    
            protected override object SaveViewState()
            {
                //object[] state = new object[3];
                //state[0] = base.SaveViewState();
                //state[1] = this.dirtyRows;
                //state[2] = this.newRows;
                //return state;
                
                return base.SaveViewState();
            }
    
            protected override void LoadViewState(object savedState)
            {
    
                //object[] state = null;
    
                //if (savedState != null)
                //{
                //    state = (object[])savedState;
                //    base.LoadViewState(state[0]);
                //    this.dirtyRows = (List<int>)state[1];
                //    this.newRows = (List<int>)state[2];
                //}
                
                base.LoadViewState(savedState);
            }
            #endregion
    
            public override string[] DataKeyNames
            {
                get
                {
                    return base.DataKeyNames;
                }
                set
                {
                    base.DataKeyNames = value;
                }
            }
    
            public override DataKeyArray DataKeys
            {
                get
                {
                    return base.DataKeys;
                }
            }
    
            public override DataKey SelectedDataKey
            {
                get
                {
                    return base.SelectedDataKey;
                }
            }
        }
    }
