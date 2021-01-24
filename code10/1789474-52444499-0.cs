    public async Task UploadFile(string id) {
        EventHandler<ProgressArgs> handler = null;
        handler = async (sender, args) => {
            await Clients.Client(args.Id).SendAsync("FTPUploadProgress", args.Progress);
        };
        progressRaised += handler;
        Progress<double> progress = new Progress<double>(x => {
            progressRaised(progress, new ProgressArgs { Progress = x, Id = id });
        }
        );
        await client.DownloadFileAsync(localPath, remotePath, true, FluentFTP.FtpVerify.Retry, progress); await client.DownloadFileAsync(localPath, remotePath, true, FluentFTP.FtpVerify.Retry, progress);
        progressRaised -= handler;
    }
    event EventHandler<ProgressArgs> progressRaised = delegate { };
    class ProgressArgs : EventArgs {
        public double Progress { get; set; }
        public string Id { get; set; }
    }
