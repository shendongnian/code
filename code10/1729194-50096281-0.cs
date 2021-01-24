    private async Task WriteAsync(CancellationToken cancellationToken)
    {
    
        Task<UInt32> storeAsyncTask;
    
        if ((WriteBytesAvailable) && (WriteBytesInputValue.Text.Length != 0))
        {
            char[] buffer = new char[WriteBytesInputValue.Text.Length];
            WriteBytesInputValue.Text.CopyTo(0, buffer, 0, WriteBytesInputValue.Text.Length);
            String InputString = new string(buffer);
            DataWriteObject.WriteString(InputString);
            WriteBytesInputValue.Text = "";
    
            // Don't start any IO if we canceled the task
            lock (WriteCancelLock)
            {
                cancellationToken.ThrowIfCancellationRequested();
    
                // Cancellation Token will be used so we can stop the task operation explicitly
                // The completion function should still be called so that we can properly handle a canceled task
                storeAsyncTask = DataWriteObject.StoreAsync().AsTask(cancellationToken);
            }
    
            UInt32 bytesWritten = await storeAsyncTask;
            if (bytesWritten > 0)
            {
                WriteBytesTextBlock.Text += InputString.Substring(0, (int)bytesWritten) + '\n';
                WriteBytesCounter += bytesWritten;
                UpdateWriteBytesCounterView();
            }
            rootPage.NotifyUser("Write completed - " + bytesWritten.ToString() + " bytes written", NotifyType.StatusMessage);
        }
        else
        {
            rootPage.NotifyUser("No input received to write", NotifyType.StatusMessage);
        }
    
    }
