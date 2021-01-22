    private void Redirect(StreamReader input, TextBox output)
    {
        new Thread(a =>
        {
            var buffer = new char[1];
            while (input.Read(buffer, 0, 1) > 0)
            {
                output.Dispatcher.Invoke(new Action(delegate
                {
                    output.Text += new string(buffer);
                }));
            };
        }).Start();
    }
    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        process = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                CreateNoWindow = true,
                FileName = "app.exe",
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                UseShellExecute = false,
            }
        };
        if (process.Start())
        {
            Redirect(process.StandardError, textBox1);
            Redirect(process.StandardOutput, textBox1);
        }
    }
