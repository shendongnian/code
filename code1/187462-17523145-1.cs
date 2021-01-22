	OracleCommand cmd = new OracleCommand("LoadXML", _oracleConnection);
	cmd.CommandType = CommandType.StoredProcedure;
	OracleParameter xmlParam = new OracleParameter("XMLFile", OracleType.Clob);
	cmd.Parameters.Add(xmlParam);
	//connection should be open!
	OracleClob clob = new OracleClob(_oracleConnection);
	// xmlData: a string with way more than 4000 chars
	clob.Write(xmlData.ToArray(),0,xmlData.Length);
	xmlParam.Value = clob; 
	try
	{
		cmd.ExecuteNonQuery();
	}
	catch (OracleException e)
	{
	}
