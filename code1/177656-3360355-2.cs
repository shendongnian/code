            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            
            foreach (DataGridViewRow  item in this.dataGridView1.Rows)
            {
                DataRow dr = dt.NewRow();
                if (item.DataBoundItem != null)
                {
                    dr = (DataRow)((DataRowView)item.DataBoundItem).Row;
                    dt.ImportRow(dr);
                }
            }
            ds.Tables.Add(dt);
