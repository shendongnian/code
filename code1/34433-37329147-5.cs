	dbParameter = new OracleParameter();
	dbParameter.ParameterName = "myparamname";
	dbParameter.UdtTypeName = StringListCustomType.Name;
    dbParameter.OracleDbType = OracleDbType.Array;
	if (myarray != null)
	{
		StringListCustomType newArray = new StringListCustomType();
		newArray.Array = myarray;
        dbParameter.Value
	}
	else
	{
		dbParameter.Value = StringListCustomType.Null;
	}
