    <!-- language: c# -->
    private void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
    {
        Task.Run(async () =>
        {
            int i = 0;
            while (true)
            {
                await Task.Delay(500);
                Dispatcher.Invoke(()=>
                {
                    Test2[1] += (ushort)2;
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(Test2)));
                });
            }
        }
    }
