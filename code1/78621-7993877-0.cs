            if (dataset != null)
            {
                datatable = dataset.Tables[0];
                DataView dataView = new DataView(datatable);
                dataView.Sort = e.SortExpression;
                GridView1.DataSource = dataView;
                GridView1.DataBind();
            }
        }
