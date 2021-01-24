    public static DataTable OleDbJoin(string csv1, string csv2, string key1, string key2)
    {
    	DataTable dt = new DataTable();
    
    	string sConn = string.Format(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0}\;Extended Properties='text;HDR=No;FMT=CSVDelimited()';", Path.GetDirectoryName(csv1));
    	string sSql = string.Format(@"SELECT T.*
    		FROM (
    			SELECT * FROM [{0}] AS t1
    			INNER JOIN (SELECT * FROM [{1}]) AS t2
    				ON t1.[{2}] = t2.[{3}]) AS T;",
    			Path.GetFileName(csv1), Path.GetFileName(csv2), key1, key2);
    
    	try
    	{
    		using (OleDbConnection oConn = new OleDbConnection(sConn))
    		{
    			using (OleDbCommand oComm = new OleDbCommand(sSql, oConn))
    			{
    				oConn.Open();
    				OleDbDataReader oRdr = oComm.ExecuteReader();
    				dt.Load(oRdr);
    				oComm.Dispose();
    				oRdr.Dispose();
    				oConn.Close();
    				oConn.Dispose();
    			}
    		}
    	}
    	catch(OleDbException ex)
    	{
    		Console.WriteLine(ex.Message);
    	}
    	catch(Exception ex)
    	{
    		Console.WriteLine(ex.Message);
    	}
    
    	return dt;
    }
