    public double ExcuteCommande(string stored_procedure,SqlParameter[] param)
    {
        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = stored_procedure;
        sqlcmd.Connection = sqlconnection;
        if (param!=null)
        {         
                sqlcmd.Parameters.AddRange(param);           
        }
        var back=sqlcmd.ExecuteScalar();
        double result;
        double.TryParse(back.ToString(), out result);
        return result;
    }
