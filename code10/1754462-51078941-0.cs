    public string lat;
        public string lon;
        public string resulttt;
     private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Sends latitude and longitude from datagridview cell clicked to their respective textboxes//
            int rowindex = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[rowindex];
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            lat = dataGridView1.Rows[e.RowIndex].Cells[16].Value.ToString();
            lon = dataGridView1.Rows[e.RowIndex].Cells[17].Value.ToString();
            resulttt = lat + " " + lon;
            //textBox1 = textBox1.Replace(",", ".").Replace(" ", ",");
        }
