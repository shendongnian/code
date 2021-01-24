    public Form1()
    {
        InitializeComponent();
        serialPort1.Open();
         Task.Run(() =>
                 {
                     while (true)
                     {
                         string lastLine = serialPort1.ReadLine();
                         label1.BeginInvoke(new Action(() =>
                                                     {
                                                         label1.Text = string.IsNullOrEmpty(lastLine)
                                                                           ? label1.Text
                                                                           : $"{lastLine}{Environment.NewLine}{label1.Text}";
                                                     }
                                           ));
                         Thread.Sleep(TimeSpan.FromSeconds(1));
                     }
                 });
    }
