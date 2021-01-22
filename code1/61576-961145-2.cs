    create table TBL_ZIP_BLOB
    (
        ID unqiuidentifier primary key clustered not null
            default newid()
        ,BLOB varbinary(max) not null,
        ,NAME nvarchar(255) not null
    )
    public void InsertZipBlob(Guid id, byte[] bytes, string name)
    {
    	SqlDbCommand.CommandText = @"insert into TBL_ZIP_BLOB(BLOB,NAME) values(@blob,@name)";
    
        using( SqlCommand cmd = MethodToGetValidCommandObject() )
        {
            cmd.CommandText = "insert into TBL_ZIP_BLOB(ID, BLOB,NAME) values(@id,@blob,@name)";
            cmd.Parameters.Add("@id",SqlDbType.UniqueIdentifier).Value	= id;
            cmd.Parameters.Add("@blob",SqlDbType.Image).Value		= bytes;
    	    cmd.Parameters.Add("@name",SqlDbType.NVarChar,128).Value    = name;
            cmd.ExecuteNonQuery();
        }
    }
    
    public void SendZipBlobToResponse(Guid id, HttpResponse response)
    {
        byte[] bytes = new byte[0];
        string name = "file.zip";
        
        using( SqlCommand cmd = MethodToGetValidCommandObject() )   
        {
            cmd.ComandText = "select BLOB,NAME from TBL_ZIP_BLOB where ID = @id";
            cmd.Parameters.Add("@id",SqlDbType.UniqueIdentifier).Value	= id;
            using( IDataReader reader = cmd.ExecuteReader() )
            {
                if( reader.Read() )
                {
                    name = (string)reader["NAME"];
    			    bytes =	(byte[])reader["BLOBIMG"];
                }
            }
        }
        
        if (bytes.Length > 0)
        {
            response.AppendHeader( "Content-Disposition", string.Format("attachment; filename=\"{0}\""),name);
    		response.AppendHeader( "Content-Type","application/zip" );
            
        	const int CHUNK = 1024;
        	byte[] buff = new byte[CHUNK];
        	for( long i=0; i<Bytes.LongLength; i+=CHUNK )
        	{
        		if( i+CHUNK > bytes.LongLength )
        			buff = new byte[Bytes.LongLength-i];
        		Array.Copy( Bytes, i, buff, 0, buff.Length );
        		response.OutputStream.Write( buff, 0, buff.Length );
        		response.OutputStream.Flush();
        	}
        }
    }
