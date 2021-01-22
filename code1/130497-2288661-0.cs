    context.Response.Clear();
    context.Response.BufferOutput = false;
    context.Response.ContentType = "application/octet-stream";
    context.Response.AddHeader("Content-Disposition", "attachment; filename=" + originalFilename);
    context.Response.AddHeader("Content-Length", fileLength.ToString());
    context.Response.Cache.SetNoStore();
    
    context.Response.Flush();
    
    downloadFailed = !context.Response.IsClientConnected;
    
    int thisChunk;
    long offset = 0;
    int chunkSize = 1024 * 8;
    byte[] bytes = new byte[chunkSize];
    
    FileStream r = File.OpenRead(localFilename);
    
    while((offset < fileLength) && !downloadFailed)
    {
    	if((fileLength - offset) < chunkSize)
    	{
    		thisChunk = (int)(fileLength - offset);
    	}
    	else
    	{
    		thisChunk = chunkSize;
    	}
    
    	r.Read(bytes, 0, chunkSize);
    
    	try
    	{
    		context.Response.BinaryWrite(bytes);
    		context.Response.Flush();
    
    		if(!context.Response.IsClientConnected)
    		{
    			downloadFailed = true;
    		}
    	}
    	catch(ObjectDisposedException ex1)
    	{
    		// Stream is closed, nothing written
    		break;
    	}
    	catch(System.IO.IOException ex3)
    	{
    		// I/O error, unknown state, abort
    		Trace.Write(ex3);
    		break;
    	}
    
    	offset += thisChunk;
    }
    
    if(!downloadFailed)
    {
    	// now update the file, statistics, etc
    }
    
    context.Response.Flush();
    
    HttpContext.Current.ApplicationInstance.CompleteRequest();
