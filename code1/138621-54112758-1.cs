        if (context.Request.InputStream.Length != int.Parse(context.Request.Headers["file-length"])) 
        { 
        	//handle this case here, e.g.
        	context.Response.StatusCode = 500;
            context.Response.StatusDescription = "(500) Internal Server Error";
        	context.Response.End();
        }
        else
        {
             //proceed with copying the stream (the first code snippet)
        }
