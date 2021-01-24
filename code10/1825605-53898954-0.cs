    private async void button1_Click(object sender, EventArgs e)
    {
        button1.Enabled = false;
        var count = 0;
        // The Progress<T> constructor captures UI context,
        // so the lambda will be run on the UI thread.
        IProgress<int> progress = new Progress<int>(value =>
        {
            label1.Text = value.ToString();
        });
        await Task.Run(() =>
        {
            for (var i = 0; i <= 500; i++)
            {
                count = i;
                progress.Report(i);
                Thread.Sleep(100);
            }
        });
        label1.Text = @"Counter " + count;
        button1.Enabled = true;
    }
