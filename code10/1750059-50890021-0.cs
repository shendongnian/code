    private void start_clock()
            {
                // Init the clock and start the thread for the clock.
                Task.Run(async () => {
                    while (true)
                    {
                        await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                        {
                            this.lbl_clock.Text = DateTime.Now.ToString("HH:mm:ss");
                        });
                        await Task.Delay(500);
                    }
                });
            }
