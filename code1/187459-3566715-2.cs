    varcmd = new OracleCommand("LoadXML", _oracleConnection);
    cmd.CommandType = CommandType.StoredProcedure;
    var xmlParam = new OracleParameter("XMLFile", OracleType.Clob);
    cmd.Parameters.Add(xmlParam);
    // DO NOT assign the parameter value yet in this place
    
    cmd.Transaction = _oracleConnection.BeginTransaction();
    try
    {
        // Assign value here, AFTER starting the TX
        xmlParam.Value = xmlWithWayMoreThan4000Characters;
        cmd.ExecuteNonQuery();
        cmd.Transaction.Commit();
    }
    catch (OracleException)
    {
        cmd.Transaction.Rollback();
    }
