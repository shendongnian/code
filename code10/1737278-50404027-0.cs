     protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
        }
        protected void grid1_PageIndexChanging(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
        {
            grid1.CurrentPageIndex = e.NewPageIndex;
            BindGrid();
        }
        private int GetNumItems()
        {
            int totalRow = 15;
            return totalRow;
        }
        private void BindGrid()
        {
          
            grid1.DataSource = GetTable();
            grid1.DataBind();
        }
        public DataTable GetTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("Name", typeof(string));
            table.Rows.Add(1, "David");
            table.Rows.Add(2, "Sam");
            table.Rows.Add(3, "Christoff");
            table.Rows.Add(4, "Janet");
            table.Rows.Add(5, "Melanie");
            table.Rows.Add(6, "David1");
            table.Rows.Add(7, "Sam1");
            table.Rows.Add(8, "Christoff1");
            table.Rows.Add(9, "Jane1t");
            table.Rows.Add(10, "Melanie1");
            return table;
        }
