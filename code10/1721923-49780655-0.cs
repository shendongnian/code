    System.Drawing.ImageConverter converter = new System.Drawing.ImageConverter();
    var buff = (byte[])converter.ConvertTo(Microsoft.Graph.Test.Properties.Resources.hamilton, typeof(byte[]));
    using (System.IO.MemoryStream ms = new System.IO.MemoryStream(buff))
    {
        // Get the provider. 
        // POST /v1.0/drive/items/01KGPRHTV6Y2GOVW7725BZO354PWSELRRZ:/_hamiltion.png:/microsoft.graph.createUploadSession
        // The CreateUploadSesssion action doesn't seem to support the options stated in the metadata.
        var uploadSession = await graphClient.Drive.Items["01KGPRHTV6Y2GOVW7725BZO354PWSELRRZ"].ItemWithPath("_hamilton.png").CreateUploadSession().Request().PostAsync();
        var maxChunkSize = 320 * 1024; // 320 KB - Change this to your chunk size. 5MB is the default.
        var provider = new ChunkedUploadProvider(uploadSession, graphClient, ms, maxChunkSize);
        // Setup the chunk request necessities
        var chunkRequests = provider.GetUploadChunkRequests();
        var readBuffer = new byte[maxChunkSize];
        var trackedExceptions = new List<Exception>();
        DriveItem itemResult = null;
        //upload the chunks
        foreach (var request in chunkRequests)
        {
            // Do your updates here: update progress bar, etc.
            // ...
            // Send chunk request
            var result = await provider.GetChunkRequestResponseAsync(request, readBuffer, trackedExceptions);
            if (result.UploadSucceeded)
            {
                itemResult = result.ItemResponse;
            }
        }
        // Check that upload succeeded
        if (itemResult == null)
        {
            // Retry the upload
            // ...
        }
    }
