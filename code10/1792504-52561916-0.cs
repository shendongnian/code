        private void button4_Click(object sender, EventArgs e)
        {
            string SName, NStackPath;
            string source=("Data Source=C:\\Users\\username\\Documents\\Visual Studio 2010\\Projects\\NStacks1\\NStacks1\\Database1.sdf");
            SqlCeConnection Con = new SqlCeConnection(source);
            try{
                Con.Open();
                string Query= "SELECT * FROM Nstacks1 WHERE ID=1";
                SqlCeCommand command = new SqlCeCommand(Query , Con);
                SqlCeDataReader dr = command.ExecuteReader();
                if (dr.Read())
                { 
                    textBox1.Text=(dr["NStacksName"].ToString());
                    label2.Text = (dr["NStacksItem"].ToString());
                }
                Con.Close();
               }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    con.Close();
                }
           }
    }
