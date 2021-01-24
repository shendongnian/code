        private void BindData()
        {
               string[] myArray = {"a","b","c"};
            
                var dt = new DataTable();
                dt.Columns.Add("key");
                dt.Columns.Add("value");
                dt.Rows.Add(1,"a");
                dt.Rows.Add(2,"b");
                dt.Rows.Add(3,"c");
                chkUsers.DataTextField = "value";
                chkUsers.DataValueField = "value";
                chkUsers.DataSource = dt;
                chkUsers.DataBind();
        }
        protected void SumitButton_Click(object sender, EventArgs e)
        {
            foreach (ListItem item in chkUsers.Items)
            {
                if (item.Selected)
                    Response.Write(item.Value);
            }
        }
