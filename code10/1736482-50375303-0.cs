    private void Form1_Load(object sender, EventArgs e)
    {
        DataGridViewComboBoxColumn cmb = new DataGridViewComboBoxColumn();
        cmb.Items.Add("AAAA");
        cmb.Items.Add("BBBB");
        cmb.Items.Add("CCCC");
        dataGridView1.Rows.Add("1st Col", "2nd Col");
        dataGridView1.Columns.Add(cmb);
    }
