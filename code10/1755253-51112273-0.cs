    public Form1()
    {
        InitializeComponent();
        once = 0;
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }
        try
        {
            FileStream config = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            config.Close();
            StreamWriter writetext = new StreamWriter(filePath);
            writetext.Write("Alarm");
            writetext.WriteLine();
            writetext.Write("Alarm Ringing!");
            writetext.WriteLine();
            writetext.Write("1");                
            writetext.Close();
        }
        catch(Exception ex)
        {
            MessageBox.Show(ex.Message, "Error!");
        }
        notificationTitle = File.ReadLines(filePath).Skip(0).Take(1).First();
        notificationText = File.ReadLines(filePath).Skip(1).Take(1).First();
    }
