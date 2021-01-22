    if (list != null && list.Any())
            {
                gridView.DataSource = list;
                gridView.DataBind();
            }
            else
            {
                MyCustomClass item = new MyCustomClass(){Id = 0, Name = "(No Data Rows)", Active = false};
                List<MyCustomClass> l = new List<MyCustomClass>();
                l.Add(item);
                gridView.DataSource = l;
                gridView.DataBind();
                gridView`enter code here`.Rows[0].Visible = false;
            }
