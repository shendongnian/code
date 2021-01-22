    var dt = "your code for getting data into datatable";
                Response.ClearContent();
                Response.AddHeader("content-disposition", string.Format("attachment;filename={0}.xls", DateTime.Now.ToString("yyyy-MM-dd")));
                Response.ContentType = "application/vnd.ms-excel";
                string tab = "";
                foreach (DataColumn dataColumn in dt.Columns)
                {
                    Response.Write(tab + dataColumn.ColumnName);
                    tab = "\t";
                }
                Response.Write("\n");
                int i;
                foreach (DataRow dataRow in dt.Rows)
                {
                    tab = "";
                    for (i = 0; i < dt.Columns.Count; i++)
                    {
                        Response.Write(tab + dataRow[i].ToString());
                        tab = "\t";
                    }
                    Response.Write("\n");
                }
                Response.End();
