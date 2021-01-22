            System.Text.StringBuilder b = new System.Text.StringBuilder();
            foreach (System.Data.DataRow r in dt.Rows)
            {
                foreach (System.Data.DataColumn c in dt.Columns)
                {
                    b.Append(c.ColumnName.ToString() + ":" + r[c.ColumnName].ToString());
                }
            }
            MessageBox.Show(b.ToString());
