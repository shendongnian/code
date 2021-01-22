    void Window_Loaded(object sender, RoutedEventArgs e)
    {
        _bw = new BackgroundWorker();
        _bw.DoWork += new DoWorkEventHandler((o, args) =>
        {
            //Long stuff here       
            this.Dispatcher.Invoke((Action)(() => txtLog.AppendText(Environment.NewLine + "Blabla")));
        });
        _bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler((o, args) =>
        {
            //End long stuff here
            this.Dispatcher.Invoke((Action)(() => this.button1.IsEnabled = true));
        });
    }
    private void button1_Click(object sender, RoutedEventArgs e)
    {
        this.button1.IsEnabled = false;
        _bw.RunWorkerAsync();
    }
