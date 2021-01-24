    public Form1()
    {
        InitializeComponent();
        serialPort1.Open();
        string currentLine = string.Empty;
        object mylock = new object();
        Task.Run(() =>
                 {
                     while (true)
                     {
                         lock (mylock)
                         {
                             string previousLine = currentLine;
                             currentLine = serialPort1.ReadLine();
                             string line = currentLine;
                             label1.BeginInvoke(new Action
                                                    (() =>
                                                     {
                                                         label1.Text = string.IsNullOrEmpty(line) || string.Equals(previousLine, line)
                                                                           ? label1.Text
                                                                           : $"{line}{Environment.NewLine}{label1.Text}";
                                                     }
                                                    ));
                             Task.Delay(TimeSpan.FromSeconds(1)).Wait();
                         }
                     }
                 });
    }
