    try
    {
        FileStream streamFile = File.Create(strLocalFilePath);
    
        sshSFTP.DownloadFile(strFilePath, streamFile,
            (ulong uiProcessedSize) =>
            {
                //Callback
                processProgress(uiProcessedSize);
    
                if(didUserAbortDownload())
                {
                    //Aborted
                    streamFile.Close();
                }
            });
    }
    catch (Exception ex)
    {
        if(didUserAbortDownload())
        {
            Console.WriteLine("Download cancelled");
        }
        else
        {
            Console.WriteLine("Download failed: " + ex.Message);
        }
    }
