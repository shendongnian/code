		public class GridViewPlus : GridView
        {
           
            public event EventHandler<CustomHeaderEventArgs> CustomHeaderTableCellCreated;
    
            private GridViewPlusCustomHeaderRows _rows;
       
            public GridViewPlus() : base ()
            {
                _rows = new GridViewPlusCustomHeaderRows();
            }
    
            /// <summary>
            /// Allow Custom Headers
            /// </summary>
            public bool ShowCustomHeader { get; set; }
    
    
            [PersistenceMode(PersistenceMode.InnerDefaultProperty)]
            [MergableProperty(false)]
            public GridViewPlusCustomHeaderRows CustomHeaderRows
            {
                get {return  _rows; }
                
            }
    
            protected virtual void OnCustomHeaderTableCellCreated(CustomHeaderEventArgs e)
            {
                EventHandler<CustomHeaderEventArgs> handler = CustomHeaderTableCellCreated;
    
                // Event will be null if there are no subscribers
                if (handler != null)
                {
                    // Use the () operator to raise the event.
                    handler(this, e);
                }
    
            }
    
            protected override void OnRowCreated(GridViewRowEventArgs e)
            {
                if (ShowCustomHeader && e.Row.RowType == DataControlRowType.Header) return;
                base.OnRowCreated(e);
            }
    
    
            protected override void PrepareControlHierarchy()
            {
                //Do not show the Gridview header if show custom header is ON
                if (ShowCustomHeader) this.ShowHeader = false;
    
    
                base.PrepareControlHierarchy();
                //Safety Check
                if (this.Controls.Count == 0)
                    return;
                bool controlStyleCreated = this.ControlStyleCreated;
                Table table = (Table)this.Controls[0];
    
                int j = 0;
                if (CustomHeaderRows ==null )return ;
    
                foreach (TableRow tr in CustomHeaderRows)
                {
                    OnCustomHeaderTableCellCreated(new CustomHeaderEventArgs(tr,j));
                    table.Rows.AddAt(j, tr);
                    tr.ApplyStyle(this.HeaderStyle);
                    j++;
                }
    
    
            }
        }
           
        public class GridViewPlusCustomHeaderRows : System.Collections.CollectionBase
        {
            public GridViewPlusCustomHeaderRows()
            {
            }
    
            public void Add(TableRow aGridViewCustomRow)
            {
                List.Add(aGridViewCustomRow);
            }
    
            public void Remove(int index)
            {
                // Check to see if there is a widget at the supplied index.
                if (index > Count - 1 || index < 0)
                // If no widget exists, a messagebox is shown and the operation 
                // is cancelled.
                {
                    throw (new Exception("Index not valid"));
                }
                else
                {
                    List.RemoveAt(index);
                }
            }
    
            public TableRow Item(int Index)
            {
                // The appropriate item is retrieved from the List object and
                // explicitly cast to the Widget type, then returned to the 
                // caller.
                return (TableRow)List[Index];
            }
            
        }
        
        
        public class CustomHeaderEventArgs : EventArgs
        {
            public CustomHeaderEventArgs(TableRow tr ,int RowNumber  )
            {
                tRow = tr;
                _rownumber = RowNumber;
            }
            private TableRow tRow;
            private int _rownumber = 0;
          
    
            public int RowNumber { get { return _rownumber; } }
    
            public TableRow HeaderRow
            {
                get { return tRow; }
                set { tRow = value; }
            }
    
         
        }
    	
    	
		public partial class _Default : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                Example1();
                GridViewExtension1.CustomHeaderTableCellCreated += new EventHandler<CustomHeaderEventArgs>(GridViewExtension1_CustomHeaderTableCellCreated);
            }
    
            void GridViewExtension1_CustomHeaderTableCellCreated(object sender, CustomHeaderEventArgs e)
            {
                TableRow tc = (TableRow)e.HeaderRow;
    
                tc.BackColor = System.Drawing.Color.AliceBlue;
            }
    
            private void Example1()
            {
                System.Data.DataTable dtSample = new DataTable();
                DataColumn dc1 = new DataColumn("Column1",typeof(string));
                DataColumn dc2 = new DataColumn("Column2",typeof(string));
                DataColumn dc3 = new DataColumn("Column3",typeof(string));
                DataColumn dc4 = new DataColumn("Column4",typeof(string));
               // DataColumn dc5 = new DataColumn("Column5",typeof(string));
                dtSample.Columns.Add(dc1);
                dtSample.Columns.Add(dc2);
                dtSample.Columns.Add(dc3);
                dtSample.Columns.Add(dc4);
               // dtSample.Columns.Add(dc5);
                dtSample.AcceptChanges();
    
                for (int i = 0; i < 25; i++)
                {
                    DataRow dr = dtSample.NewRow();
    
                    for (int j = 0; j < dtSample.Columns.Count; j++)
                    {
                        dr[j] = j;
                    }
                    dtSample.Rows.Add(dr);
                }
                dtSample.AcceptChanges();
                //GridViewExtension1.ShowHeader = false;
                GridViewExtension1.ShowCustomHeader = true;
    
                /*
                 *=======================================================================
                 *  |Row 1 Cell 1   |   Row 1 Col 2 (Span=2)        | Row 1 Col 3   |
                 *  |               |                               |               |
                 *=======================================================================             
                 *  |Row 2 Cell 1   |               |               |               |
                 *  |               |   Row 2 Col 2 | Row 2 Col 3   |Row 2 Col 4    |
                 *=======================================================================
                 * 
                 * 
                 * 
                 * 
                 * */
    
                // SO we have to make 2 header row as shown above
    
                TableRow TR1 = new TableRow();
                TableCell tcR1C1 = new TableCell();
                tcR1C1.Text = "Row 1 Cell 1";
                tcR1C1.ColumnSpan = 1;
                TR1.Cells.Add(tcR1C1);       
    
                TableCell tcR1C2 = new TableCell();
                tcR1C2.Text = "Row 1 Cell 2";
                tcR1C2.ColumnSpan = 2;
                TR1.Cells.Add(tcR1C2);  
    
                TableCell tcR1C3 = new TableCell();
                tcR1C3.Text = "Row 1 Cell 3";
                tcR1C3.ColumnSpan = 1;
                TR1.Cells.Add(tcR1C3);
    
    
                GridViewExtension1.CustomHeaderRows.Add(TR1);
    
                TableRow TR2 = new TableRow();
                TableCell tcR2C1 = new TableCell();
                tcR2C1.Text = "Row 2 Cell 1";
                tcR2C1.ColumnSpan = 1;
                TR2.Cells.Add(tcR2C1);
    
                TableCell tcR2C2 = new TableCell();
                tcR2C2.Text = "Row 2 Cell 2";
                tcR2C2.ColumnSpan = 1;
                TR2.Cells.Add(tcR2C2);
    
                TableCell tcR2C3 = new TableCell();
                tcR2C3.Text = "Row 2 Cell 3";
                tcR2C3.ColumnSpan = 1;
                TR2.Cells.Add(tcR2C3);
    
                TableCell tcR2C4 = new TableCell();
                tcR2C4.Text = "Row 2 Cell 4";
                tcR2C4.ColumnSpan = 1;
                TR2.Cells.Add(tcR2C4);
    
                GridViewExtension1.CustomHeaderRows.Add(TR2);
    
    
                GridViewExtension1.DataSource = dtSample;
                GridViewExtension1.DataBind();
    
            }
        }
