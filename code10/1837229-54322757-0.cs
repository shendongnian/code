     private async void UpdateDetails()
    {
          Task.Run(async () =>
        {
             Device.BeginInvokeOnMainThread(() => { details.Children.Clear();
              details.Children.Add(Helpers.Activity.Create());});
              var newGrid = await doLongRunningDatabaseTaskandCreateXAML();
              Device.BeginInvokeOnMainThread(() => {  details.Children.Clear();
              details.Children.Add(Helpers.Activity.Create(newGrid);});
        }
    }
