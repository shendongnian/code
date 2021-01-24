            private void PostProgressChanged(AsyncOperation asyncOp, ProgressData progress) {
            if (asyncOp != null && progress.BytesSent + progress.BytesReceived > 0)
            {
                int progressPercentage;
                if (progress.HasUploadPhase)
                {
                    if (progress.TotalBytesToReceive < 0 && progress.BytesReceived == 0)
                    {
                        progressPercentage = progress.TotalBytesToSend < 0 ? 0 : progress.TotalBytesToSend == 0 ? 50 : (int)((50 * progress.BytesSent) / progress.TotalBytesToSend);
                    }
                    else
                    {
                        progressPercentage = progress.TotalBytesToSend < 0 ? 50 : progress.TotalBytesToReceive == 0 ? 100 : (int) ((50 * progress.BytesReceived) / progress.TotalBytesToReceive + 50);
                    }
                    asyncOp.Post(reportUploadProgressChanged, new UploadProgressChangedEventArgs(progressPercentage, asyncOp.UserSuppliedState, progress.BytesSent, progress.TotalBytesToSend, progress.BytesReceived, progress.TotalBytesToReceive));
                }
                else
                {
                    progressPercentage = progress.TotalBytesToReceive < 0 ? 0 : progress.TotalBytesToReceive == 0 ? 100 : (int) ((100 * progress.BytesReceived) / progress.TotalBytesToReceive);
                    asyncOp.Post(reportDownloadProgressChanged, new DownloadProgressChangedEventArgs(progressPercentage, asyncOp.UserSuppliedState, progress.BytesReceived, progress.TotalBytesToReceive));
                }
            }
        }
