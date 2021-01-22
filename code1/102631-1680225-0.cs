     DataTable dt = new DataTable();
                dt.Columns.Add("val", Type.GetType("System.Int32"));
                DataRow dr;
                for (int i = 1; i <= 31; i++)
                {
                    dr = dt.NewRow();
                    dr[0] = i;
                    dt.Rows.Add(dr);
                }
                dt.AcceptChanges();
                DataView dv = dt.DefaultView;
                dv.Sort = "val desc";
                ddlDay.DataTextField = "val";
                ddlDay.DataValueField = "val";
                ddlDay.DataSource = dv.ToTable();
                ddlDay.DataBind();
