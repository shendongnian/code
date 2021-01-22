    // Get Stream of the file
    fileReader = new StreamReader(File.Open(this.FileName, FileMode.Open));
    
    FileInfo fileInfo = new FileInfo(this.FileName);
    
    long bytesRead = 0;
    
    // Change the 75 for performance.  Find a number that suits your application best
    int bufferLength = 1024 * 75;
    
    while (!fileReader.EndOfStream)
    {
        double completePercent = ((double)bytesRead / (double)fileInfo.Length);
    
        // I am using my own Progress Bar Dialog I left in here to show an example
        this.ProgressBar.UpdateProgressBar(completePercent);
    
        int readLength = bufferLength;
    
        if ((fileInfo.Length - bytesRead) < readLength)
        {
            // There is less in the file than the lenght I am going to read so change it to the 
            // smaller value
            readLength = (int)(fileInfo.Length - bytesRead);
        }
    
        char[] buffer = new char[readLength];
    
        // GEt the next chunk of the file
        bytesRead += (long)(fileReader.Read(buffer, 0, readLength));
    
        // This will help the file load much faster
        string currentLine = new string(buffer).Replace("\n", string.Empty);
    
        // Load in background
        this.Dispatcher.BeginInvoke(new Action(() =>
            {
                TextRange range = new TextRange(textBox.Document.ContentEnd, textBox.Document.ContentEnd);
                range.Text = currentLine;
    
            }), DispatcherPriority.Normal);
    }
