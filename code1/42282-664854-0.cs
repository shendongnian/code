            DataTable dt = new DataTable();
            private void Form1_Load(object sender, EventArgs e)
            {
                dt.Columns.Add("a");
                dt.Columns.Add("b");
                dt.Rows.Add("aaa", "bbb");
                dataGrid1.DataSource = dt;
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                dt.Rows.Add("111", "222");
            }
