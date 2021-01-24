    public async Task UploadFile(string id) {
        EventHandler<ProgressArgs> handler = null;
        //creating the handler inline for compactness
        handler = async (sender, args) => {
            //send message to client asynchronously
            await Clients.Client(args.Id).SendAsync("FTPUploadProgress", args.Progress);
        };
        progressRaised += handler; //subscribe to event
        Progress<double> progress = new Progress<double>(x => {
            //raise event with progress and client id to be handled
            progressRaised(progress, new ProgressArgs { Progress = x, Id = id });
        }
        );
        //use the progress as you normally would
        await client.DownloadFileAsync(localPath, remotePath, true, FluentFTP.FtpVerify.Retry, progress); await client.DownloadFileAsync(localPath, remotePath, true, FluentFTP.FtpVerify.Retry, progress);
        //unsubscribe when done 
        progressRaised -= handler;
    }
    /// <summary>
    /// event to be raised when progress is reported
    /// </summary>
    event EventHandler<ProgressArgs> progressRaised = delegate { };
    /// <summary>
    /// EventArgs used to pass the client id and current progress reported
    /// </summary>
    class ProgressArgs : EventArgs {
        public double Progress { get; set; }
        public string Id { get; set; }
    }
