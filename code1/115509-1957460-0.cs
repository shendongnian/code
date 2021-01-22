    // The DataSource SHOULD BE a DataSet. 
    // No check is implemented on this point.
    
    namespace EnterpriseUtilities.Webcontrols
    {
    	/// <summary>
    	/// Creates a nested data grid.
    	/// </summary>
    	public class NestedDataGrid : System.Web.UI.WebControls.DataGrid
    	{
    		/// <summary>
    		/// The width.
    		/// </summary>
    		public Unit HostColumnWidth;
    		private DataGrid detailsGrid;
    		/// <summary>
    		/// Gets or sets the item to render expanded.
    		/// </summary>
    		public int ExpandedItem
    		{
    			get {return Convert.ToInt32(ViewState["ExpandedItem"]);}
    			set {ViewState["ExpandedItem"] = value;}
    		}
    		/// <summary>
    		/// Gets or sets whether the child grid is scrollable or pageable
    		/// </summary>
     		public bool ScrollChildren
    		{
    			get {return Convert.ToBoolean(ViewState["ScrollChildren"]);}
    			set {ViewState["ScrollChildren"] = value;}
    		}
    		/// <summary>
    		/// Gets or sets the name of the DataSet's relation to use to fill the subgrid.
    		/// </summary>
    		public string RelationName
    		{
    			get {return Convert.ToString(ViewState["RelationName"]);}
    			set {ViewState["RelationName"] = value;}
    		}
    		/// <summary>
    		/// Fire the UpdateView event to the page for binding.
    		/// </summary>
    		public event EventHandler UpdateView;
    		private void OnUpdateView()
    		{
    			if (UpdateView != null)
    				UpdateView(this, EventArgs.Empty); 
    		}
    		/// <summary>
    		/// Public ctor
    		/// </summary>
    		public NestedDataGrid() : base()
    		{
    			ExpandedItem = -1;
    			HostColumnWidth = Unit.Pixel(150);
    			ScrollChildren = true;
    
    			AllowPaging = true;
    			PageIndexChanged += new DataGridPageChangedEventHandler(NestedDataGrid_PageIndexChanged);
    			ItemCommand += new DataGridCommandEventHandler(NestedDataGrid_ItemCommand);
    			ItemDataBound += new DataGridItemEventHandler(NestedDataGrid_ItemDataBound);
    		}
    		/// <summary>
    		/// Page change handler.
    		/// </summary>
    		/// <param name="sender">The sender.</param>
    		/// <param name="e">The page changed event.</param>
    		private void NestedDataGrid_PageIndexChanged(object sender, DataGridPageChangedEventArgs e)
    		{
    			CurrentPageIndex = e.NewPageIndex;
    			SelectedIndex = -1;
    			EditItemIndex = -1;
    			ExpandedItem = -1;
    
    			OnUpdateView();
    		}
    		/// <summary>
    		/// Command handler.
    		/// </summary>
    		/// <param name="source">The sender.</param>
    		/// <param name="e">The event args.</param>
    		private void NestedDataGrid_ItemCommand(object source, DataGridCommandEventArgs e)
    		{
    			if (e.CommandName != "Expand")
    				return;
    
    			ExpandItem(e.Item);
    		}
    		/// <summary>
    		/// Adjust the index of the expanded item.
    		/// </summary>
    		/// <param name="item">The item.</param>
    		private void ExpandItem(DataGridItem item)
    		{
    			if (item.ItemIndex == (ExpandedItem % this.PageSize))
    				SetExpandedItem(item, false);
    			else
    				SetExpandedItem(item, true);
    
    			OnUpdateView();
    		}
    		/// <summary>
    		/// Adjust the index of the expanded item
    		/// </summary>
    		/// <param name="item">The item.</param>
    		/// <param name="expand">If true then item is expanded.</param>
    		private void SetExpandedItem(DataGridItem item, bool expand)
    		{
    			if (expand)
    				ExpandedItem = (this.PageSize*this.CurrentPageIndex+item.ItemIndex); 
    			else
    				ExpandedItem = -1;
    		}
    		/// <summary>
    		/// Opens the subtree and shows the related records.
    		/// </summary>
    		/// <param name="item">The item.</param>
    		/// <param name="columns">The associated columns.</param>
    		protected override void InitializeItem(DataGridItem item, DataGridColumn[] columns)
    		{
    			for (int i=0; i<columns.Length; i++)
    			{
    				TableCell cell = new TableCell();
    				if (columns[i] is ExpandCommandColumn)
    					((ExpandCommandColumn)columns[i]).InitializeCell(cell, i, item.ItemType, (item.ItemIndex==(ExpandedItem % this.PageSize)));
    				else
    					columns[i].InitializeCell(cell, i, item.ItemType);
    				item.Cells.Add(cell);
    			}
    		}
    		/// <summary>
    		/// Modify the layout of the cell being expanded.
    		/// </summary>
    		/// <param name="sender">The sender.</param>
    		/// <param name="e">The event args.</param>
    		private void NestedDataGrid_ItemDataBound(object sender, DataGridItemEventArgs e)
    		{
    			// Process only items and alternating items
    			if (e.Item.ItemType != ListItemType.Item &&
    				e.Item.ItemType != ListItemType.AlternatingItem)
    				return;
    
    			// Default if the item doesn't have to be expanded
    			if (e.Item.ItemIndex != (ExpandedItem % this.PageSize))
    			{
    				// Instead of itemstyle-width set declaratively
    				e.Item.Cells[1].Width = HostColumnWidth;
    
    				return;
    			}
    
    			// Build the subtree
    			BuildChildLayout(e.Item);
    		}
    		/// <summary>
    		/// Modify the layout of the cell being expanded.
    		/// </summary>
    		/// <param name="item">The item.</param>
    		private void BuildChildLayout(DataGridItem item)
    		{
    			DataGridItem row = item;
    
    			// Assumes the Expand column is the first
    
    			// Remove all cells	but one
    			int cellsToSpanOver = row.Cells.Count-1;
    			ArrayList listOfText = new ArrayList();
    			ArrayList listOfWidth = new ArrayList();
    			for (int i=row.Cells.Count-1; i>0; i--)
    			{
    				listOfText.Add(row.Cells[i].Text);
    				if (i==1) // Add the width of the column whose width is not declared
    					listOfWidth.Add(HostColumnWidth);
    				else
    					listOfWidth.Add(this.Columns[i].ItemStyle.Width);
    				row.Cells.RemoveAt(i);
    			}
    
    			// Add the new cell that will host the child grid
    			TableCell newCell = new TableCell();
    			newCell.ColumnSpan = cellsToSpanOver;
    			newCell.BackColor = Color.SkyBlue;
    
    			// MUST BE empty. If you set a fixed width declaratively that value
    			// will override this one. For this reason, we set the width of the 
    			// first column after the EXPAND column dynamically. We also assume
    			// that the first column after the EXPAND column is the host cell, where
    			// the child grid is inserted.
    			newCell.Width = Unit.Empty;
    			row.Cells.Add(newCell);
    			
    			// The child layout is made of a 2-row table: header (same as the 
    			// previous unexpanded row) and the subgrid
    			Table t = new Table();
    			t.Font.Name = this.Font.Name;
    			t.Font.Size = this.Font.Size;
    			t.CellSpacing = this.CellSpacing;
    			t.CellPadding = this.CellSpacing;
    			t.BorderWidth = this.BorderWidth;
    
    			TableRow rowHeader = new TableRow();
    			t.Rows.Add(rowHeader);
    			TableRow rowSubGrid = new TableRow();
    			t.Rows.Add(rowSubGrid);
    			newCell.Controls.Add(t);
    
    			// Fill the header row
    			for (int i=listOfText.Count-1; i>=0; i--)
    			{
    				TableCell c = new TableCell();
    				c.Text = listOfText[i].ToString();
    				c.Width = (Unit) listOfWidth[i];
    				rowHeader.Cells.Add(c);
    			}
    		
    			
    			// Fill the second row
    			Panel outerPanel = null;
    			if (ScrollChildren)
    			{
    				outerPanel = new Panel();
    				outerPanel.Height = Unit.Pixel(100);
    				outerPanel.Style["overflow"] = "auto"; 
    			}
    
    			TableCell cellSubGrid = new TableCell();
    			cellSubGrid.ColumnSpan = cellsToSpanOver;
    			cellSubGrid.BackColor = Color.LightCyan;
    			rowSubGrid.Cells.Add(cellSubGrid);
    
    			detailsGrid = new DataGrid();
    			detailsGrid.ID = "detailsGrid";
    			detailsGrid.BackColor = Color.LightCyan;
    			detailsGrid.Font.Name = this.Font.Name;
    			detailsGrid.Font.Size = this.Font.Size;
    			detailsGrid.HeaderStyle.Font.Bold = true; 
    			detailsGrid.Width = Unit.Percentage(100);
    
    			if (!ScrollChildren)
    			{
    				detailsGrid.AllowPaging = true;
    				detailsGrid.PageSize = 5;
    				detailsGrid.PageIndexChanged += new DataGridPageChangedEventHandler(detailsGrid_PageIndexChanged);
    			}
    			BindDetails(detailsGrid);
    
    			if (ScrollChildren)
    			{
    				outerPanel.Controls.Add(detailsGrid);
    				cellSubGrid.Controls.Add(outerPanel);
    			}
    			else
    			{
    				cellSubGrid.Controls.Add(detailsGrid);
    			}
    		}		
    		/// <summary>
    		/// Bind the child view to the subgrid.
    		/// </summary>
    		/// <param name="detailsGrid">The grid.</param>
    		private void BindDetails(DataGrid detailsGrid)
    		{
    			DataSet ds = (DataSource as DataSet);
    			if (ds == null)
    				return;
    
    			DataTable dt = ds.Tables[this.DataMember];
    			DataView theView = new DataView(dt);
    			DataRowView drv = theView[ExpandedItem];	 
    			DataView detailsView = drv.CreateChildView(this.RelationName);
    
    			detailsGrid.DataSource = detailsView;
    			detailsGrid.DataBind();
    		}
    		/// <summary>
    		/// Takes care of paging the child grid.
    		/// </summary>
    		/// <param name="sender">The sender.</param>
    		/// <param name="e">The event args.</param>
    		private void detailsGrid_PageIndexChanged(object sender, DataGridPageChangedEventArgs e)
    		{
    			DataGrid detGrid = (DataGrid) sender;
    			detGrid.CurrentPageIndex = e.NewPageIndex;
    			//Page.Trace.Warn("Child grid page: " + detGrid.CurrentPageIndex.ToString());
    			BindDetails(detGrid);
    		}
    	}
    }
