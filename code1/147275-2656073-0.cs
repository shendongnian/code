    public void Execute()
    {
    	isExecuting = true;
    	byte[] data;
    	byte[] cmpData;
    
    	//create temp zip file
    	OnMessage("Reading file to memory");
    
    	byte[] data = File.ReadAllBytes(  PathToFile );
    	
    	OnMessage("Zipping file to memory");
    	byte[] compressedData = Compress(data);
    	
    	OnMessage("Saving file to database");
    	SaveToDatabase( compressedData );
    	
    	OnMessage("File Saved");
    	isExecuting = false;
    }
    
    private void SaveToDatabase( byte[] data )
    {
    	 using ( var cmd = Conn.CreateCommand() )
    	{
    		cmd.CommandText = @"MergeFileUploads";
    		cmd.CommandType = CommandType.StoredProcedure;
    		cmd.Parameters.AddWithValue("@File", data );
    		cmd.Parameters["@File"].DbType = DbType.Binary;
    		
    		cmd.Parameters.Add("@SourceField");
    		var parameter = cmd.Parameters["@SourceField"];
    		parameter.DbType = DbType.Int32;
    		parameter.Direction = ParameterDirection.Output;
    		
    		cmd.ExecuteNonQuery();
    		sourceFileId = (int)parameter.Value;
    	}
    }
    
    private static byte[] Compress( byte[] data )
    {
    	var output = new MemoryStream();
    	using ( var gzip = new GZipStream( output, CompressionMode.Compress, true ) )
    	{
    		gzip.Write( data, 0, data.Length );
    		gzip.Close();
    	}
    	return output.ToArray();
    }
    private static byte[] Decompress( byte[] data )
    {
    	var output = new MemoryStream();
    	var input = new MemoryStream();
    	input.Write( data, 0, data.Length );
    	input.Position = 0;
    
    	using ( var gzip = new GZipStream( input, CompressionMode.Decompress, true ) )
    	{
    		var buff = new byte[64];
    		var read = gzip.Read( buff, 0, buff.Length );
    
    		while ( read > 0 )
    		{
    			output.Write( buff, 0, read );
    			read = gzip.Read( buff, 0, buff.Length );
    		}
    
    		gzip.Close();
    	}
    	return output.ToArray();
    }
	
