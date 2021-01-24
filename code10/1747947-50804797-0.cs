    protected void Page_Load(object sender, EventArgs e)
        {
            List<Student> lista = new List<Student>();
            lista.Add(new Student() { Id = 1, Name = "Nesta" });
            lista.Add(new Student() { Id = 2, Name = "Pirlo" });
            lista.Add(new Student() { Id = 3, Name = "Maldini" });
            GridTest.DataSource = lista;
            GridTest.DataBind();
        }
        protected void GridTest_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            CheckBox chk = new CheckBox();
            chk.EnableViewState = true;
            chk.Enabled = true;
            chk.Checked = true;
            chk.Text = "Test";
            chk.ID = "chkb";
            e.Row.Cells[0].Controls.Add(chk);
        }
        protected void ClickIt_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GridTest.Rows)
            {
                var val = (CheckBox)row.FindControl("chkb");
                var name = val.Text;
                var boolvalue = val.Checked;
            }
        }
