    // Writes the BLOB to a file (*.bmp).  
    FileStream stream;                            
    // Streams the BLOB to the FileStream object.  
    BinaryWriter writer;                          
    
    // Size of the BLOB buffer.  
    int bufferSize = 100;                     
    // The BLOB byte[] buffer to be filled by GetBytes.  
    byte[] outByte = new byte[bufferSize];    
    // The bytes returned from GetBytes.  
    long retval;                              
    // The starting position in the BLOB output.  
    long startIndex = 0;                      
    
    // Open the connection and read data into the DataReader.  
    connection.Open();  
    SqlDataReader reader = command.ExecuteReader(CommandBehavior.SequentialAccess);  
    
    while (reader.Read())  
    {  
    
      // Create a file to hold the output.  
      stream = new FileStream(  
        "some-physical-file-name-to-dump-data.bmp", FileMode.OpenOrCreate, FileAccess.Write);  
      writer = new BinaryWriter(stream);  
    
      // Reset the starting byte for the new BLOB.  
      startIndex = 0;  
    
      // Read bytes into outByte[] and retain the number of bytes returned.  
      retval = reader.GetBytes(1, startIndex, outByte, 0, bufferSize);  
    
      // Continue while there are bytes beyond the size of the buffer.  
      while (retval == bufferSize)  
      {  
        writer.Write(outByte);  
        writer.Flush();  
    
        // Reposition start index to end of last buffer and fill buffer.  
        startIndex += bufferSize;  
        retval = reader.GetBytes(1, startIndex, outByte, 0, bufferSize);  
      }  
    
      // Write the remaining buffer.  
      writer.Write(outByte, 0, (int)retval);  
      writer.Flush();  
    
      // Close the output file.  
      writer.Close();  
      stream.Close();  
    }  
    
    // Close the reader and the connection.  
    reader.Close();  
    connection.Close();
