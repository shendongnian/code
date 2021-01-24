        public DoLongRunningOperation()
        {
            Task.Run(() =>
            {
                for (var i = 0; i < 100; i++)
                {
                    // Do some really cpu intense stuff.. 
                    Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Render, new Action(() =>
                    {
                        ProgressValue = i;
                    }));
                }
            });
        }
