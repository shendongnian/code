    using System;
    using System.Web.UI.WebControls;
    using System.Web.UI.HtmlControls;
    using System.Web.UI;
    
    namespace Diplo.WebControls.DataControls.PagerTemplates
    {
    	/// <summary>
    	/// Paging template for the <see cref="DiploGridView"/>
    	/// </summary>
    	public class RowsPagePreviousNext : ITemplate
    	{
    		readonly PagedDataSource _pagedDataSource;
    		readonly DiploGridView DiploGridView;
    
    		/// <summary>
    		/// Initializes a new instance of the <see cref="RowsPagePreviousNext"/> class.
    		/// </summary>
    		/// <param name="pagedDataSource">The <see cref="PagedDataSource"/>.</param>
    		/// <param name="DiploGrid">A reference to the <see cref="DiploGridView"/>.</param>
    		public RowsPagePreviousNext(PagedDataSource pagedDataSource, DiploGridView DiploGrid)
    		{
    			_pagedDataSource = pagedDataSource;
    			DiploGridView = DiploGrid;
    		}
    
    		/// <summary>
    		/// When implemented by a class, defines the <see cref="T:System.Web.UI.Control"></see> object that child controls and templates belong to. These child controls are in turn defined within an inline template.
    		/// </summary>
    		/// <param name="container">The <see cref="T:System.Web.UI.Control"></see> object to contain the instances of controls from the inline template.</param>
    		void ITemplate.InstantiateIn(Control container)
    		{
    			Literal space = new Literal();
    			space.Text = "&nbsp;";
    
    			HtmlGenericControl divLeft = new HtmlGenericControl("div");
    			divLeft.Style.Add("float", "left");
    			divLeft.Style.Add(HtmlTextWriterStyle.Width, "25%");
    
    			Label lb = new Label();
    			lb.Text = "Show rows: ";
    			divLeft.Controls.Add(lb);
    
    			DropDownList ddlPageSize = new DropDownList();
    			ListItem item;
    			ddlPageSize.AutoPostBack = true;
    			ddlPageSize.ToolTip = "Select number of rows per page";
    
    			int max = (_pagedDataSource.DataSourceCount < 50) ? _pagedDataSource.DataSourceCount : 50;
    			int i;
    			const int increment = 5;
    			bool alreadySelected = false;
    			for (i = increment; i <= max; i = i + increment)
    			{
    				item = new ListItem(i.ToString());
    				if (i == _pagedDataSource.PageSize)
    				{
    					item.Selected = true;
    					alreadySelected = true;
    				}
    				ddlPageSize.Items.Add(item);
    			}
    
    			item = new ListItem("All", _pagedDataSource.DataSourceCount.ToString());
    			if (_pagedDataSource.DataSourceCount == _pagedDataSource.PageSize && alreadySelected == false)
    			{
    				item.Selected = true;
    				alreadySelected = true;
    			}
    
    			if (_pagedDataSource.DataSourceCount > (i - increment) && alreadySelected == false)
    			{
    				item.Selected = true;
    			}
    
    			ddlPageSize.Items.Add(item);
    
    			ddlPageSize.SelectedIndexChanged += new EventHandler(ddlPageSize_SelectedIndexChanged);
    
    			divLeft.Controls.Add(ddlPageSize);
    
    			HtmlGenericControl divRight = new HtmlGenericControl("div");
    			divRight.Style.Add("float", "right");
    			divRight.Style.Add(HtmlTextWriterStyle.Width, "75%");
    			divRight.Style.Add(HtmlTextWriterStyle.TextAlign, "right");
    
    			Literal lit = new Literal();
    			lit.Text = String.Format("Found {0} record{1}. Page ", 
    				_pagedDataSource.DataSourceCount, 
    				(_pagedDataSource.DataSourceCount == 1) ? String.Empty : "s" );
    			divRight.Controls.Add(lit);
    
    			TextBox tbPage = new TextBox();
    			tbPage.ToolTip = "Enter page number";
    			tbPage.Columns = 2;
    			tbPage.MaxLength = 3;
    			tbPage.Text = (_pagedDataSource.CurrentPageIndex + 1).ToString();
    			tbPage.CssClass = "pagerTextBox";
    			tbPage.AutoPostBack = true;
    			tbPage.TextChanged += new EventHandler(tbPage_TextChanged);
    			divRight.Controls.Add(tbPage);
    			if (_pagedDataSource.PageCount < 2)
    				tbPage.Enabled = false;
    
    			lit = new Literal();
    			lit.Text = " of " + _pagedDataSource.PageCount;
    			divRight.Controls.Add(lit);
    
    			divRight.Controls.Add(space);
    
    			Button btn = new Button();
    			btn.Text = "";
    			btn.CommandName = "Page";
    			btn.CommandArgument = "Prev";
    			btn.SkinID = "none";
    			btn.Enabled = !_pagedDataSource.IsFirstPage;
    			btn.CssClass = (btn.Enabled) ? "buttonPreviousPage" : "buttonPreviousPageDisabled";
    			if (btn.Enabled)
    				btn.ToolTip = "Previous page";
    			divRight.Controls.Add(btn);
    
    			btn = new Button();
    			btn.Text = "";
    			btn.CommandName = "Page";
    			btn.CommandArgument = "Next";
    			btn.SkinID = "none";
    			btn.CssClass = "buttonNext";
    			btn.Enabled = !_pagedDataSource.IsLastPage;
    			btn.CssClass = (btn.Enabled) ? "buttonNextPage" : "buttonNextPageDisabled";
    			if (btn.Enabled)
    				btn.ToolTip = "Next page";
    			divRight.Controls.Add(btn);
    
    			container.Controls.Add(divLeft);
    			container.Controls.Add(divRight);
    		}
    
    		/// <summary>
    		/// Handles the TextChanged event of the tbPage control.
    		/// </summary>
    		/// <param name="sender">The source of the event.</param>
    		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    		void tbPage_TextChanged(object sender, EventArgs e)
    		{
    			TextBox tb = sender as TextBox;
    			
    			if (tb != null)
    			{
    				int page;
    				if (int.TryParse(tb.Text, out page))
    				{
    					if (page <= _pagedDataSource.PageCount && page > 0)
    					{
    						DiploGridView.PageIndex = page - 1;
    					}
    				}
    			}
    		}
    
    		/// <summary>
    		/// Handles the SelectedIndexChanged event of the ddlPageSize control.
    		/// </summary>
    		/// <param name="sender">The source of the event.</param>
    		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    		void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
    		{
    			DropDownList list = sender as DropDownList;
    			if (list != null) DiploGridView.PageSize = Convert.ToInt32(list.SelectedValue);
    		}
    	}
    }
