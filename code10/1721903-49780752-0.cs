    public string SaveLoad(DataGL.ScheduledMaintenance objmaster)
    {
        try
        {
	    OracleConnection connection = this.AppConnection;
	    connection.Open();
	    OracleTransaction transaction = connection.BeginTransaction();
	    OracleCommand cmd = new OracleCommand("PKG_VHSCHDULEMAINTENANCE.USP_SAVE", connection, transaction);
	    cmd.CommandType = CommandType.StoredProcedure;
	    OracleParameter parameter = new OracleParameter("p_HostBranchId",OracleType.Number);
	    parameter.Value = objmaster.intBranchId;
	    cmd.Parameters.Add(parameter); 
	    OracleParameter parameter = new OracleParameter("p_UserId",OracleType.Number);
	    parameter.Direction = ParameterDirection.Output;
	    parameter.Value = objmaster.intUserId;
	    cmd.Parameters.Add(parameter); 
	    OracleParameter parameter = new OracleParameter("p_OutMsg",OracleType.VarChar,100);
	    parameter.Direction = ParameterDirection.Output;
	    cmd.Parameters.Add(parameter);
	    cmd.ExecuteNonQuery();
	    string strResult = "";
	    strResult = cmd.Parameters["p_OutMsg"].Value.ToString();
	    connection.CommitTransaction();
            return strResult;
        }
        catch (Exception exc)
        {
        }
        finally
        {
            connection.close();
        }
