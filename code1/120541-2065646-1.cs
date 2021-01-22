    private string sqlversion(string sqlver)
    {
        OdbcConnection conn = null;
        try
        {
            conn = getConnection(comboBoxDatabase.Text);
            string strSql = "SELECT @@VERSION";
            conn.Open();
            OdbcCommand cmd = new OdbcCommand(strSql, conn);
            string returnvalue = (string)cmd.ExecuteScalar();
            return returnvalue;
        }
        catch (Exception ex){ }
        finally
        {
            conn.Close();
        }
    }
