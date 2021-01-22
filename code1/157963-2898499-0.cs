    public static LastByteRead = 0; // keep it zero indexed
    
    public String[] GetFileChunk( String path, long chunkByteSize )
    {
    	FileStream fStream;
    	String[] FileTextLines;
    	int SuccessBytes = 0;
    	long StreamSize;
    	byte[] FileBytes;
    	char[] FileTextChars;
    	Decoder UtfDecoder = Encoding.UTF8.GetDecoder();
    	FileInfo TextFileInfo = new FileInfo(path);
    	
    	if( File.Exists(path) )
    	{
    		try {
    			StreamSize = (TextFileInfo.Length >= chunkByteSize) ? chunkByteSize : TextFileInfo.Length;
    			fStream = new FileStream( path, FileMode.Open, FileAccess.Read );
    			FileBytes = new byte[ StreamSize ];
    			FileTextChars = new char[ StreamSize ]; // this can be same size since it's UTF-8 (8bit chars)
    			
    			SuccessBytes = fStream.Read( FileBytes, 0, (Int32)StreamSize );
    			
    			if( SuccessBytes > 0 )
    			{
    				UtfDecoder.GetChars( FileBytes, 0, StreamSize, FileTextChars, 0 );
    				LastByteRead = SuccessBytes - 1;
    				
    				return 
    					String.Concat( fileTextChars.ToArray<char>() ).Split('\n');
    			}
    			
    			else
    				return new String[1] {""};
    		}
    		
    		catch {
    			var errorException = "ERROR: " + ex.Message;
                Console.Writeline( errorException );
            }
            
            finally {
                fStream.Close();
            }	
    	}	
    }
