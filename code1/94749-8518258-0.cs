            TaskScheduler currentTaskScheduler = TaskScheduler.FromCurrentSynchronizationContext();
            Task<string>.Factory.StartNew(() =>
            {
                // loop for about 10s with 10ms step
                for (int i = 0; i < 1000; i++)
                {
                    Thread.Sleep(10);
                    Task.Factory.StartNew(() =>
                    {
                        // this is a task created each time you want to update to the UI thread.
                        this.Text = i.ToString();
                    }, CancellationToken.None, TaskCreationOptions.None, currentTaskScheduler);
                }
                return "Finished!";
            })
            .ContinueWith(t =>
            {
                // this is a new task will be run after the main task complete!
                this.Text += " " + t.Result;
            }, currentTaskScheduler);
