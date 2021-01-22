        SqlConnection cn = new SqlConnection(@"Connection_String");
        SqlDataAdapter adp;
        SqlCommandBuilder cb;
        DataTable dt;
        private void Form3_Load(object sender, EventArgs e)
        {
            adp= new SqlDataAdapter("select * from temp", cn);
            cb = new SqlCommandBuilder(adp);
            dt = new DataTable();
            dt.Columns.Add("SrNo", typeof(int));
            dt.Columns[0].AutoIncrement = true;
            dt.Columns[0].AutoIncrementSeed = 1;
            dt.Columns[0].AutoIncrementStep = 1;
            adp.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            adp.Update(dt);
        }  
