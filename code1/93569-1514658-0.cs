    DownloadThread = new Thread(new ThreadStart(DownloadFiles));
    DownloadThread.Start();
    private void DownloadFiles()
    {
        foreach (DownloadingFile df in DownloadingFileList)
        {
            if (df.Size != "<DIR>") //don't download a directory
            {
                ReadBytesThread = new Thread(() => { 
                  FileData = sendPassiveFTPcmd("RETR " + df.Path + "/" + df.Name + "\r\n");
                  FileStream fs = new FileStream(@"C:\Downloads\" + df.Name, 
                                                 FileMode.Append);
                  fs.Write(FileData, 0, FileData.Length);
                  fs.Close();
                                                    });
                ReadBytesThread.Start();
                ReadBytesThread.Join();
                if (DownloadListView.InvokeRequired)
                {
                    DownloadListView.Invoke(new MethodInvoker(delegate(){
                        MessageBox.Show("Downloaded");
                    }));
                }
            }
        }        
    }
