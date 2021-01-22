    try
	{
		// Open the file.
		iStream = new System.IO.FileStream(filepath, System.IO.FileMode.Open, 
					System.IO.FileAccess.Read,System.IO.FileShare.Read);
		// Total bytes to read:
		dataToRead = iStream.Length;
		Response.ContentType = "application/octet-stream";
		Response.AddHeader("Content-Disposition", "attachment; filename=" + filename);
		// Read the bytes.
  		while (dataToRead > 0)
		{
			// Verify that the client is connected.
			if (Response.IsClientConnected) 
			{
				// Read the data in buffer.
				length = iStream.Read(buffer, 0, 10000);
				// Write the data to the current output stream.
				Response.OutputStream.Write(buffer, 0, length);
				// Flush the data to the HTML output.
				Response.Flush();
				buffer= new Byte[10000];
				dataToRead = dataToRead - length;
			}
			else
			{
				//prevent infinite loop if user disconnects
				dataToRead = -1;
			}
		}
	}
	catch (Exception ex) 
	{
		// Trap the error, if any.
		Response.Write("Error : " + ex.Message);
	}
	finally
	{
		if (iStream != null) 
		{
			//Close the file.
			iStream.Close();
		}
		Response.Close();
	}
