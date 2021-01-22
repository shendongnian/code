    private async void Button_Click(object sender, EventArgs e)
    {
        button.Enabled = false;
        try
        {
            var progress = new Progress<string>(s => button.Text = s);
            await Task.Run(() => SecondThreadConcern.FailingWork(progress));
            button.Text = "Completed";
        }
        catch(Exception exception)
        {
            button.Text = "Failed: " + exception.Message;
        }
        button.Enabled = true;
    }
    class SecondThreadConcern
    {
        public static void FailingWork(IProgress<string> progress)
        {
            progress.Report("I will fail in...");
            Task.Delay(500).Wait();
            for (var i = 0; i < 3; i++)
            {
                progress.Report((3 - i).ToString());
                Task.Delay(500).Wait();
            }
            throw new Exception("Oops...");
        }
    }
