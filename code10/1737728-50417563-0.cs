    FileSystemWatcher fileWatcher = new FileSystemWatcher();
    string filePath = @"./Log.txt";
    public MainWindow()
    {
        InitializeComponent();
        ReadFromTxt();
        FileWatherConfigure();
    }
    public void FileWatherConfigure()
    {
        fileWatcher.Path = System.IO.Path.GetDirectoryName(filePath);
        fileWatcher.Filter = System.IO.Path.GetFileName(filePath);
        fileWatcher.Changed += FileWatcher_Changed;
        fileWatcher.EnableRaisingEvents = true;
    }
    private void FileWatcher_Changed(object sender, FileSystemEventArgs e)
    {
        Thread.Sleep(TimeSpan.FromSeconds(1));
        ReadFromTxt();
    }
    void ReadFromTxt()
    {
        string[] lines = System.IO.File.ReadAllLines(filePath);
        MyTextBox.Dispatcher.Invoke(() => { this.MyTextBox.Text = string.Join(Environment.NewLine, lines); });
    }
