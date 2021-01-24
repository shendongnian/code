    public async Task UploadFile(string id) {
        EventHandler<double> handler = null;
        //creating the handler inline for compactness
        handler = async (sender, value) => {
            //send message to client asynchronously
            await Clients.Client(id).SendAsync("FTPUploadProgress", value);
        };
        var progress = new Progress<double>();
        progress.ProgressChanged += handler;//subscribe to ProgressChanged event
        //use the progress as you normally would
        await client.DownloadFileAsync(localPath, remotePath, true, FluentFTP.FtpVerify.Retry, progress);
       
        //unsubscribe when done 
        progress.ProgressChanged -= handler;
    }
