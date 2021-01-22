        private void Form1_Load(object sender, EventArgs e)
        {
            DataTable dt = JetMetaData.AllColumns("", Properties.Settings.Default.JetConnection);
            String RowFilter = "TABLE_NAME = 'YourTableName'";
            DataView drv = dt.DefaultView;
            drv.RowFilter = RowFilter;
            DataGridView dgv = this.dataGridView1;
            dgv.DataSource = drv;
        }
