    Public void FileSystemWatcher_Created(Object Sender, FileSystemEventArgs e)
    {
        string filePath = e.FullPath;
        Action action = async () =>
        {
           await Task.Delay(10);
          pdfwindow.WbPdf.Navigate(filepath);
        };
        Dispatcher.BeginInvoke(action);
     }
