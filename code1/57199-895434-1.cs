            DataSet ds = new DataSet("Records DS");
            ds.Tables.Add("Records");
            foreach (XElement record in table.Descendants("Record"))
            {
                var temp = from r in record.Descendants("Field")
                           select r.Value;
                string[] datum = temp.ToArray();
                if (datum != null
                    && datum.Length > 0)
                {
                    foreach (string s in datum)
                        ds.Tables[0].Columns.Add();
                    DataRow row = ds.Tables[0].NewRow();
                    row.ItemArray = datum;
                    ds.Tables[0].Rows.Add(row);
                }
            }
