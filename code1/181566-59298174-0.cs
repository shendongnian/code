            string category = ddlcat.SelectedItem.Value; // this can be any input by user
            DataTable dt = filter_dt; //filter_dt is DataTable object, contains actual data, from there we will filter
            DataView dataView = dt.DefaultView;
            if (!string.IsNullOrEmpty(category))
            {
                dataView.RowFilter = "Category = '" + category + "'";
            }
            Gridview1.DataSource = dataView;
            Gridview1.DataBind();
