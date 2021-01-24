    for (int i = 0; i < ds.Tables[0].Columns.Count; i++)
            {
                BoundField bf = new BoundField();
                bf.DataField = ds.Tables[0].Columns[i].ColumnName;
                bf.HeaderText = ds.Tables[0].Columns[i].ColumnName;
                grid_additional_test.Columns.Add(bf);
            }
    grid_additional_test.DataSource = ds.Tables[0].DefaultView;
    grid_additional_test.DataBind();
