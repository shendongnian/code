    int chunkSize = 1024 * 1024 * 5;
    using (Stream streamx = new FileStream(file.Path, FileMode.Open, FileAccess.Read))
     {
        byte[] buffer = new byte[chunkSize];
        int bytesRead = 0;
        long bytesToRead = streamx.Length;
        while (bytesToRead > 0)
        {
            int n = streamx.Read(buffer, 0, chunkSize);
        
            if (n == 0) break;
            // Let's resize the last incomplete buffer
            if (n != buffer.Length)
               Array.Resize(ref buffer, n);
            // do work on buffer...
            // uploading chunk ....
            var partRequest = HttpHelpers.InvokeHttpRequestStream
                (
                    new Uri(endpointUri + "?partNumber=" + i + "&uploadId=" + UploadId),
                    "PUT",
                     partHeaders,
                     buffer
                );  // upload buffer
        
            bytesRead += n;
            bytesToRead -= n;
        }
        
     }   
