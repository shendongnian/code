    // (... some other parameters to add ...)
    
    cmd.Transaction = _oracleConnection.BeginTransaction();
    try
    {
        // assign value here, after starting the TX
        xmlParam.Value = xmlData; // xmlData: a string with way more than 4000 chars
        cmd.ExecuteNonQuery();
        cmd.Transaction.Commit();
    }
    catch (OracleException e)
    {
        cmd.Transaction.Rollback();
    }
