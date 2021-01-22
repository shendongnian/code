    private async void Button_Clicked(object sender, EventArgs e)
    {
        var progress = new Progress<string>(s => label.Text = s);
        await Task.Factory.StartNew(() => Concern.LongWork(progress),
                                    TaskCreationOptions.LongRunning);
        label.Text = "completed";
    }
    class Concern
    {
        public static void LongWork(IProgress<string> progress)
        {
            // Perform a long running work...
            for (var i = 0; i < 10; i++)
            {
                Task.Delay(500).Wait();
                progress.Report(i.ToString());
            }
        }
    }
