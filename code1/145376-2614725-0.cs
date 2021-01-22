    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
    {
        string connStr = "Data Source=M1-PC;Initial Catalog=master;Integrated Security=True;Pooling=False";
        using(SqlConnection conn = new SqlConnection(connStr))
        {
           string sqlStmt = String.Format("BACKUP DATABASE LA TO DISK='{0}'", saveFileDialog1.FileName);
           using(SqlCommand bu2 = new SqlCommand(sqlStmt, conn))
           {
               conn.Open();
               bu2.ExecuteNonQuery();
               conn.Close();
          
               MessageBox.Show("ok");
           }
        }
   }
