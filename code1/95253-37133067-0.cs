    private void PostProgressChanged(AsyncOperation asyncOp, WebClient.ProgressData progress)
      {
          if (asyncOp == null || progress.BytesSent + progress.BytesReceived <= 0L)
              return;
          if (progress.HasUploadPhase)
          {
              int progressPercentage = progress.TotalBytesToReceive >= 0L || progress.BytesReceived != 0L
                  ? (progress.TotalBytesToSend < 0L
                      ? 50
                      : (progress.TotalBytesToReceive == 0L
                          ? 100
                          : (int) (50L*progress.BytesReceived/progress.TotalBytesToReceive + 50L)))
                  : (progress.TotalBytesToSend < 0L
                      ? 0
                      : (progress.TotalBytesToSend == 0L ? 50 : (int) (50L*progress.BytesSent/progress.TotalBytesToSend)));
              
              asyncOp.Post(this.reportUploadProgressChanged,
                  (object)
                      new UploadProgressChangedEventArgs(progressPercentage, asyncOp.UserSuppliedState,
                          progress.BytesSent, progress.TotalBytesToSend, progress.BytesReceived,
                          progress.TotalBytesToReceive));
          }
          else
          {
              int progressPercentage = progress.TotalBytesToReceive < 0L
                  ? 0
                  : (progress.TotalBytesToReceive == 0L
                      ? 100
                      : (int) (100L*progress.BytesReceived/progress.TotalBytesToReceive));
              asyncOp.Post(this.reportDownloadProgressChanged,
                  (object)
                      new DownloadProgressChangedEventArgs(progressPercentage, asyncOp.UserSuppliedState,
                          progress.BytesReceived, progress.TotalBytesToReceive));
          }
      }
