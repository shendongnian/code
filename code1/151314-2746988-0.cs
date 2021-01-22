    using System;
    using System.Collections;
    using System.Drawing;
    using System.Web.UI.WebControls;
    using Diplo.WebControls.DataControls.PagerTemplates;
    using Image=System.Web.UI.WebControls.Image;
    
    namespace Diplo.WebControls.DataControls
    {
    	/// <summary>
    	/// Extended <see cref="GridView"/> with some additional cool properties
    	/// </summary>
    	public class DiploGridView : GridView
    	{
    		#region Properties
    
    		/// <summary>
    		/// Gets or sets a value indicating whether a sort graphic is shown in column headings
    		/// </summary>
    		/// <value><c>true</c> if sort graphic is displayed; otherwise, <c>false</c>.</value>
    		public bool EnableSortGraphic
    		{
    			get
    			{
    				object o = ViewState["EnableSortGraphic"];
    				if (o != null)
    				{
    					return (bool)o;
    				}
    				return true;
    			}
    			set
    			{
    				ViewState["EnableSortGraphic"] = value;
    			}
    		}
    
    		/// <summary>
    		/// Gets or sets the sort ascending image when <see cref="EnableSortGraphic"/> is <c>true</c>
    		/// </summary>
    		public string SortAscendingImage
    		{
    			get
    			{
    				object o = ViewState["SortAscendingImage"];
    				if (o != null)
    				{
    					return (string)o;
    				}
    				return Page.ClientScript.GetWebResourceUrl(GetType(), SharedWebResources.ArrowUpImage);
    			}
    			set
    			{
    				ViewState["SortAscendingImage"] = value;
    			}
    		}
    
    		/// <summary>
    		/// Gets or sets the sort descending image <see cref="EnableSortGraphic"/> is <c>true</c>
    		/// </summary>
    		public string SortDescendingImage
    		{
    			get
    			{
    				object o = ViewState["SortDescendingImage"];
    				if (o != null)
    				{
    					return (string)o;
    				}
    				return Page.ClientScript.GetWebResourceUrl(GetType(), SharedWebResources.ArrowDownImage);
    			}
    			set
    			{
    				ViewState["SortDescendingImage"] = value;
    			}
    		}
    
    		/// <summary>
    		/// Gets or sets the custom pager settings mode.
    		/// </summary>
    		public CustomPagerMode CustomPagerSettingsMode
    		{
    			get
    			{
    				object o = ViewState["CustomPagerSettingsMode"];
    				if (o != null)
    				{
    					return (CustomPagerMode)o;
    				}
    				return CustomPagerMode.None;
    			}
    			set
    			{
    				ViewState["CustomPagerSettingsMode"] = value;
    			}
    		}
    
    		/// <summary>
    		/// Gets or sets a value indicating whether the columns in the grid can be re-sized in the UI
    		/// </summary>
    		/// <value><c>true</c> if  column resizing is allowed; otherwise, <c>false</c>.</value>
    		public bool AllowColumnResizing
    		{
    			get
    			{
    				object o = ViewState["AllowColumnResizing"];
    				if (o != null)
    				{
    					return (bool)o;
    				}
    				return false;
    			}
    			set
    			{
    				ViewState["AllowColumnResizing"] = value;
    			}
    		}
    
    		/// <summary>
    		/// Gets or sets the highlight colour for the row
    		/// </summary>
    		public Color RowStyleHighlightColour
    		{
    			get
    			{
    				object o = ViewState["RowStyleHighlightColour"];
    				if (o != null)
    				{
    					return (Color)o;
    				}
    				return Color.Empty;
    			}
    			set
    			{
    				ViewState["RowStyleHighlightColour"] = value;
    			}
    		}
    
    		#endregion Properties
    
    		#region Enums
    
    		/// <summary>
    		/// Represents additional custom paging modes
    		/// </summary>
    		public enum CustomPagerMode
    		{
    			/// <summary>
    			/// No custom paging mode
    			/// </summary>
    			None,
    			/// <summary>
    			/// Shows the rows drop-down list <i>and</i> the previous and next buttons
    			/// </summary>
    			RowsPagePreviousNext,
    			/// <summary>
    			/// Only shows the previous and next buttons
    			/// </summary>
    			PagePreviousNext
    		}
    
    		#endregion
    
    		#region Overridden Events
    
    		/// <summary>
    		/// Initializes the pager row displayed when the paging feature is enabled.
    		/// </summary>
    		/// <param name="row">A <see cref="T:System.Web.UI.WebControls.GridViewRow"></see> that represents the pager row to initialize.</param>
    		/// <param name="columnSpan">The number of columns the pager row should span.</param>
    		/// <param name="pagedDataSource">A <see cref="T:System.Web.UI.WebControls.PagedDataSource"></see> that represents the data source.</param>
    		protected override void InitializePager(GridViewRow row, int columnSpan, PagedDataSource pagedDataSource)
    		{
    			switch (CustomPagerSettingsMode)
    			{
    				case CustomPagerMode.RowsPagePreviousNext:
    					PagerTemplate = new RowsPagePreviousNext(pagedDataSource, this);
    					break;
    				case CustomPagerMode.PagePreviousNext:
    					PagerTemplate = new PagePreviousNext(pagedDataSource, this);
    					break;
    				case CustomPagerMode.None:
    					break;
    				default:
    					break;
    			}
    
    			base.InitializePager(row, columnSpan, pagedDataSource);
    		}
    
    		/// <summary>
    		/// Raises the <see cref="E:System.Web.UI.Control.PreRender"></see> event.
    		/// </summary>
    		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
    		protected override void OnPreRender(EventArgs e)
    		{
    			if (AllowColumnResizing && Visible)
    			{
    				string vars = String.Format("var _DiploGridviewId = '{0}';\n", ClientID);
    
    				if (!Page.ClientScript.IsClientScriptBlockRegistered("Diplo_GridViewVars"))
    				{
    					Page.ClientScript.RegisterClientScriptBlock(GetType(), "Diplo_GridViewVars", vars, true);
    				}
    
    				Page.ClientScript.RegisterClientScriptInclude("Diplo_GridView.js",
    				                                              Page.ClientScript.GetWebResourceUrl(GetType(), "Diplo.WebControls.SharedWebResources.Diplo_GridView_Resize.js"));
    			}
    
    			base.OnPreRender(e);
    		}
    
    		/// <summary>
    		/// Raises the <see cref="E:System.Web.UI.WebControls.GridView.RowCreated"></see> event.
    		/// </summary>
    		/// <param name="e">A <see cref="T:System.Web.UI.WebControls.GridViewRowEventArgs"></see> that contains event data.</param>
    		protected override void OnRowCreated(GridViewRowEventArgs e)
    		{
    			if (EnableSortGraphic)
    			{
    				if (!((e.Row == null)) && e.Row.RowType == DataControlRowType.Header)
    				{
    					foreach (TableCell cell in e.Row.Cells)
    					{
    						if (cell.HasControls())
    						{
    							LinkButton button = ((LinkButton)(cell.Controls[0]));
    							if (!((button == null)))
    							{
    								Image image = new Image();
    								image.ImageUrl = "images/default.gif";
    								image.ImageAlign = ImageAlign.Baseline;
    								if (SortExpression == button.CommandArgument)
    								{
    									image.ImageUrl = SortDirection == SortDirection.Ascending ? SortAscendingImage : SortDescendingImage;
    									Literal space = new Literal();
    									space.Text = "&nbsp;";
    									cell.Controls.Add(space);
    									cell.Controls.Add(image);
    								}
    							}
    						}
    					}
    				}
    			}
    
    			if (RowStyleHighlightColour != Color.Empty)
    			{
    				if (e.Row != null)
    				{
    					if (e.Row.RowType == DataControlRowType.DataRow)
    					{
    						e.Row.Attributes.Add("onmouseover", String.Format("this.style.backgroundColor='{0}'", ColorTranslator.ToHtml(RowStyleHighlightColour)));
    						e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=''");
    					}
    				}
    			}
    
    			base.OnRowCreated(e);
    		}
    
    		/// <summary>
    		/// Creates the control hierarchy that is used to render a composite data-bound control based on the values that are stored in view state.
    		/// </summary>
    		protected override void CreateChildControls()
    		{
    			base.CreateChildControls();
    
    			CheckShowPager();
    		}
    
    		private void CheckShowPager()
    		{
    			if (CustomPagerSettingsMode != CustomPagerMode.None && AllowPaging)
    			{
    				if (TopPagerRow != null)
    				{
    					TopPagerRow.Visible = true;
    				}
    
    				if (BottomPagerRow != null)
    				{
    					BottomPagerRow.Visible = true;
    				}
    			}
    		}
    
    		/// <summary>
    		/// Creates the control hierarchy used to render the <see cref="T:System.Web.UI.WebControls.GridView"></see> control using the specified data source.
    		/// </summary>
    		/// <param name="dataSource">An <see cref="T:System.Collections.IEnumerable"></see> that contains the data source for the <see cref="T:System.Web.UI.WebControls.GridView"></see> control.</param>
    		/// <param name="dataBinding">true to indicate that the child controls are bound to data; otherwise, false.</param>
    		/// <returns>The number of rows created.</returns>
    		protected override int CreateChildControls(IEnumerable dataSource, bool dataBinding)
    		{
    			int i = base.CreateChildControls(dataSource, dataBinding);
    
    			CheckShowPager();
    
    			return i;
    		}
		#endregion Overridden Events
	}
    }
