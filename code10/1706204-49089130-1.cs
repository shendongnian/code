               string query = "INSERT INTO 
              info('id','seed','password','ip') VALUES 
             (NULL,'"+seed.Text+ "','" +password.Text+ "',NULL)";
             con.Open();
              MysqlCommand cmd = new 
              MysqlCommand(query,con);
              cmd.ExecuteNonQuery();
               con.Close();
            MessageBox.Show("INSERTED SUCCESSFULLY !!! ");  
        }
    }
}
