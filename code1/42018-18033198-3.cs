        private async void Button_Clicked(object sender, EventArgs e)
        {
            var progress = new Progress<string>(s => label.Text = s);
            await Task.Factory.StartNew(() => SecondThreadConcern.LongWork(progress),
                                        TaskCreationOptions.LongRunning);
            label.Text = "completed";
        }
