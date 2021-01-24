    public Form1()
    {
    InitializeComponent();
    //serialPort1.Open();
    string lastLine = string.Empty;
    Task.Run(() =>
             {
                 while (true)
                 {
                     string tailValue = lastLine;
                     lastLine = serialPort1.ReadLine();
                     string line = lastLine;
                     label1.BeginInvoke(new Action
                                            (() =>
                                             {
                                                 label1.Text = string.IsNullOrEmpty(line) || string.Equals(tailValue, line)
                                                                   ? label1.Text
                                                                   : $"{line}{Environment.NewLine}{label1.Text}";
                                             }
                                            ));
                     Thread.Sleep(TimeSpan.FromSeconds(1));
                 }
             });
}
