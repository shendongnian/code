    private void Form1_Load(object sender, EventArgs e)
    {
            dgGridView.Rows.Add(new DataGridViewRow());
            dgGridView.Rows.Add(new DataGridViewRow());
            dgGridView.Rows.Add(new DataGridViewRow());
    
            dgGridView.Rows[0].Cells[0].Value = "Feb 01 2018 00:00:00";
            dgGridView.Rows[0].Cells[1].Value = "Feb 03 2018 06:00:45";
            dgGridView.Rows[1].Cells[0].Value = "Feb 02 2018 17:00:00";
            dgGridView.Rows[1].Cells[1].Value = "Feb 03 2018 21:54:21";
            dgGridView.Rows[2].Cells[0].Value = "Feb 04 2017 10:00:00";
            dgGridView.Rows[2].Cells[1].Value = "Feb 07 2018 08:23:26";
    }
