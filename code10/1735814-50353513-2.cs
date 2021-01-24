     timer.Elapsed += async (sender, args) =>
        {
             for (int i = 0; i < 15; i++)
             {
                await Task.Delay(1000);
                ...
             }
        }
