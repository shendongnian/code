     private void Form1_Load(object sender, EventArgs e)
            {
                SQLQuery s = new SQLQuery("*", "table", "", "id");
                pagedGrid1.SetPagedDataSource(s, bindingNavigator1);
            }
