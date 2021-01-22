    private delegate void FileOpenDelegate(string filename);
    
    public void OpenFile(string filename)
    {
       FileOpenDelegate fileOpenDelegate = OpenFileAsync;
       AsyncCallback callback = AsyncCompleteMethod;
       fileOpenDelegate.BeginInvoke(filename, callback, state);
    }
    
    private void OpenFileAsync(string filename)
    {
       // file opening code here, and then do whatever with the file
    }
