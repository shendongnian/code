        private void Form1_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("id");
            dt.Columns.Add("name");
            dt.Columns.Add("quantity");
            DataRow dr;
            dr = dt.NewRow();
            dr["id"] = "1";
            dr["name"] = "mobile";
            dr["quantity"] = "100";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["id"] = "2";
            dr["name"] = "laptop";
            dr["quantity"] = "50";
            dt.Rows.Add(dr);
            this.dataGridView1.DataSource = dt;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.ClearSelection();
                dataGridView1.Rows[i].Selected = true;
                if (dataGridView1.SelectedCells.Count > 0)
                {
                    int selectedrowindex = dataGridView1.SelectedCells[i].RowIndex;
                    DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
                    string _name = Convert.ToString(selectedRow.Cells["name"].Value);
                    decimal _quantity = Convert.ToDecimal(selectedRow.Cells["quantity"].Value);
                    MessageBox.Show("name: " + "quantity: " + _quantity.ToString());
                    dataGridView1.Rows[i].Selected = false;
                }
            }
        }
