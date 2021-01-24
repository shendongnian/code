        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateDgv1();
        }
        private void UpdateDgv1()
        {
            DataSet ds = new DataSet();
            DataTable dt1 = new DataTable();
            dt1.Columns.Add("Items", typeof(string));
            dt1.Columns.Add("Status", typeof(bool));
            dt1.Rows.Add("hello");
            dt1.Rows.Add("hello");
            ds.Tables.Add(dt1);
            dgv1.DataSource = dt1;
            dgv1.AllowUserToAddRows = false;
        }
