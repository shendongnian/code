    public int SelectedRowIndex { get; set; }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Test Records  
                GridView1.DataSource = Enumerable.Range(1, 5).Select(a => new
                {
                    FirstName = String.Format("First Name {0}", a),
                    LastName = String.Format("Last Name {0}", a),
                });
                GridView1.DataBind();
            }  
        }
        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer'";
                e.Row.ToolTip = "Click to select row";
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridView1, "Select$" + e.Row.RowIndex);
            }
        }
        
        protected void btnUp_Click(object sender, EventArgs e)
        {
            var rows = GridView1.Rows.Cast<GridViewRow>().Where(a => a != GridView1.SelectedRow).ToList();
            //If First Item, insert at end (rotating positions)  
            if (GridView1.SelectedRow.RowIndex.Equals(0))
            {
                rows.Add(GridView1.SelectedRow);
                SelectedRowIndex = GridView1.Rows.Count -1;
            }
            else
            {
                SelectedRowIndex = GridView1.SelectedRow.RowIndex - 1;
                rows.Insert(GridView1.SelectedRow.RowIndex - 1, GridView1.SelectedRow);
            }
            RebindGrid(rows);
        }
        protected void btnDown_Click(object sender, EventArgs e)
        {
            var rows = GridView1.Rows.Cast<GridViewRow>().Where(a => a != GridView1.SelectedRow).ToList();
            //If Last Item, insert at beginning (rotating positions)  
            if (GridView1.SelectedRow.RowIndex.Equals(GridView1.Rows.Count - 1))
            {
                rows.Insert(0, GridView1.SelectedRow);
                SelectedRowIndex = 0;
            }
            else
            {
                SelectedRowIndex = GridView1.SelectedRow.RowIndex + 1;
                rows.Insert(GridView1.SelectedRow.RowIndex + 1, GridView1.SelectedRow);
            }
            RebindGrid(rows);
        }
        private void RebindGrid(IEnumerable<GridViewRow> rows)
        {
            GridView1.DataSource = rows.Select(a => new
            {
                FirstName = ((Label)a.FindControl("txtFirstName")).Text,
            }).ToList();
            GridView1.SelectedIndex = SelectedRowIndex;
            GridView1.DataBind();
        }
