        try
            {
                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[4] { new DataColumn("Id", typeof(int)),
                            new DataColumn("Name", typeof(string)),
                            new DataColumn("Country",typeof(string)),
                            new DataColumn("Status",typeof(bool))
                });
                dt.Rows.Add(1, "John Hammond", "United States", true);
                dt.Rows.Add(2, "Mudassar Khan", "India", false);
                dt.Rows.Add(3, "Suzanne Mathews", "France", false);
                dt.Rows.Add(4, "Robert Schidner", "Russia", true);
                #region Cloned
                DataTable dtCloned = dt.Clone();
                dtCloned.Columns[3].DataType = typeof(string);
                foreach (DataRow row in dt.Rows)
                {
                    dtCloned.ImportRow(row);
                }
                foreach (DataRow row in dtCloned.Rows)
                {
                    row[3] = (row[3].ToString().ToLower() == "true") ? "Active" : "InActive";
                }
                #endregion
                GridView1.DataSource = dtCloned;
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                throw;
            }
