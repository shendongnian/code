        delegate void SetProgressDelegate(int percentComplete);
        /// <summary>
        /// A thread-safe method for updating the file download progress bar.
        /// </summary>
        /// <param name="bytesReceived"></param>
        /// <param name="totalBytes"></param>
        void SetDownloadProgress(int percentComplete)
        {
            if (this.InvokeRequired)
            {
                SetProgressDelegate d = new SetProgressDelegate(SetDownloadProgress);
                this.Invoke(d, new object[] { percentComplete });
            }
            else
            {
                this.progressFileDownload.Value = percentComplete;
            }
        }
        /// <summary>
        /// Event handler to update the progress bar during file download.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void web_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            SetDownloadProgress(e.ProgressPercentage);
        }
