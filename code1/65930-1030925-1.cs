        public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindGrid();
        }
        private void BindGrid()
        {
            List<Person> persons = new List<Person>
            {
                new Person{ID = 1, IsActive = true, Name = "Test 1"},
                new Person{ID = 2, IsActive = true, Name = "Test 2"},
                new Person{ID = 3, IsActive = true, Name = "Test 3"}
            };
            grdView.DataSource = persons;
            grdView.DataBind();
        }
        protected void grdView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdView.EditIndex = e.NewEditIndex;
            
            grdView.DataBind();
        }
        protected void grdView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdView.EditIndex = -1;
            grdView.DataBind();
        }
        protected void grdView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Person p = e.Row.DataItem as Person;
            if (p == null)
                return;
            var lbl = e.Row.Cells[2].FindControl("lblIsActive") as Label;
            if (lbl != null)
            {
                lbl.Text = p.IsActive ? "Yes" : "No";
            }
            else
            {
                var chkIsActive = e.Row.Cells[2].FindControl("chkIsActive") as CheckBox;
                if (chkIsActive != null)
                {
                    if (p != null)
                        chkIsActive.Checked = p.IsActive;
                }
            }
        }
    }
    class Person
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
