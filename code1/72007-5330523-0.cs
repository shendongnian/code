            //get data w/ sort expression
            DataTable dt = (DataTable)gridview1.DataSource;
            
            //bind sorted data to another control
            chartcontrol.datasource = dt.DefaultView.ToTable();
            chartcontrol.databind();
            //add sorted ids to session to get crazy with
            if (dt != null)
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    sb.Append(dt.DefaultView[i]["ID"].ToString() + ",");
                }
                if (sb.Length > 0)
                    sb.Remove(sb.Length - 1, 1);
                Session["SortedIDs"] = sb.ToString();
             }
