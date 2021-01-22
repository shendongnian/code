    public void ShowStatus(string message)
    {
       this.Dispatcher.BeginInvoke((Action)(() =>
           {
               textBlock.Text = message;
           }));
    }
