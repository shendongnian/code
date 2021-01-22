        private void button1_Click(object sender, EventArgs e)
        {
            string name = txtname.Text;
            string num = txtnum.Text;
            OdbcConnection con = new OdbcConnection("dsn=naveenk_m5");
            OdbcCommand cmd = new OdbcCommand("{call proc1(?,?)}",con);
            cmd.Parameters.Add("@parm1", OdbcType.VarChar).Value=name;
            cmd.Parameters.Add("@parm2", OdbcType.VarChar).Value = num;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("inserted a row");
        }
