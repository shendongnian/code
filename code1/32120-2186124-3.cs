    public void setParameter(String paramAT, String paramTxt)
    {
        OleDbCommand myCommand;
        DbParameter parameter = myCommand.CreateParameter();
        parameter.ParameterName = paramAT;
        parameter.Value = paramTxt;
        myCommand.Parameters.Add(parameter);
    }
    public int CreateDVD()
    {
        try
        {
            string strSqldvd = "INSERT INTO DVD(title,locatie)VALUES(@title,@locate?)";
            myCommand = (OleDbCommand)dbconn.MyProvider.CreateCommand();
            dbconn.MyConnection.Open();
            myCommand.Connection = dbconn.MyConnection;
            myCommand.CommandText = strSqldvd;
            setParameter("@title",M.Title );
            setParameter("@locate", M.Location);
        }
        catch (Exception)
        {
            throw new ArgumentException();
        }
        int count = myCommand.ExecuteNonQuery();
        dbconn.MyConnection.Close();
        return count;
    }
