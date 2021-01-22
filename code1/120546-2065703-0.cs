    private void buttonOK_Click(object sender, System.EventArgs e)
    {
        string strSqlVersion = sqlversion();
        MessageBox.Show(strSqlVersion);
    }
    
    private string sqlversion(string sqlver)
    {
        
        try
        {
            using (OdbcConnection conn = new OdbcConnection(comboBoxDatabase.Text))
            {
                string strSql = "SELECT @@VERSION";
                using (OdbcCommand cmd = new OdbcCommand(strSql, conn))
                {
                    conn.Open();
                    string returnvalue = Convert.ToString(cmd.ExecuteScalar());
                    return returnvalue;
                }
            }
        }
        catch (Exception ex){ }
        finally
        {
            conn.Close();
        }
    }
