    public class MyWindow : Window
    {
      public MyWindow()
      {
        InitializeComponent();
        FileSystemWatcher watcher = new FileSystemWatcher();
        watcher.Path = @"D:\";
        watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName;
        watcher.Filter = "Log.txt";
        // Add event handlers.
        watcher.Changed += new FileSystemEventHandler(OnFileChanged);
        watcher.Created += new FileSystemEventHandler(OnFileChanged);
        watcher.Renamed += new RenamedEventHandler(OnFileRenamed);
        // Begin watching.
        watcher.EnableRaisingEvents = true;
        ReadFromTxt();
      }
      private void OnFileChanged(object source, FileSystemEventArgs e)
      {
        ReadFromTxt();
      }
      private void OnFileRenamed(object source, RenamedEventArgs e)
      {
        ReadFromTxt();
      }
      private void ReadFromTxt()
      {
        // The easiest way is to just replace the whole text
        MyTextBox.Text = "";
        string[] lines = System.IO.File.ReadAllLines(@"D:\Log.txt");
        foreach (string line in lines)
        {
          MyTextBox.AppendText(line + Environment.NewLine);
        }
      }
    }
