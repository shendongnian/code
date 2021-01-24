        private async void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            ProgressBarEvent.GetInstance().Start();
            await Task.Run(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    ProgressBarEvent.GetInstance().SendProgress(i);
                    Thread.Sleep(100);
                }
                ProgressBarEvent.GetInstance().Stop();
            });
        }
