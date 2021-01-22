        Stream iStream = null;
    // Buffer to read 10K bytes in chunk:
    byte[] buffer = new Byte[10000];
    // Length of the file:
    int length;
    // Total bytes to read:
    long dataToRead;
    if (File.Exists(localfilename))
    {
        try
        {
            // Open the file.
            iStream = new System.IO.FileStream(localfilename, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.Read);
            
            // Total bytes to read:
            dataToRead = iStream.Length;
            context.Response.Clear();
            context.Response.Buffer = false;
            context.Response.ContentType = "application/octet-stream";
            Int64 fileLength = iStream.Length;
            context.Response.AddHeader("Content-Length", fileLength.ToString());
            context.Response.AddHeader("Content-Disposition", "attachment; filename=" + originalFilename);
            
            // Read the bytes.
            while (dataToRead > 0)
            {
                // Verify that the client is connected.
                if (context.Response.IsClientConnected)
                {
                    // Read the data in buffer.
                    length = iStream.Read(buffer, 0, 10000);
                    // Write the data to the current output stream.
                    context.Response.OutputStream.Write(buffer, 0, length);
                    // Flush the data to the HTML output.
                    context.Response.Flush();
                    buffer = new Byte[10000];
                    dataToRead = dataToRead - length;
                }
                else
                {
                    //prevent infinite loop if user disconnects
                    dataToRead = -1;
                }
            }
            iStream.Close();
            iStream.Dispose();
        }
        catch (Exception ex)
        {
            if (iStream != null)
            {
                iStream.Close();
                iStream.Dispose();
            }
            if (ex.Message.Contains("The remote host closed the connection"))
            {
                context.Server.ClearError();
                context.Trace.Warn("GetFile", "The remote host closed the connection");
            }
            else
            {
                context.Trace.Warn("IHttpHandler", "DownloadFile: - Error occurred");
                context.Trace.Warn("IHttpHandler", "DownloadFile: - Exception", ex);
            }
            context.Response.Redirect("default.aspx");
        }
    }
