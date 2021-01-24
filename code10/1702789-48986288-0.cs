    private async void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        var dispatcher = CoreWindow.GetForCurrentThread().Dispatcher;
    
        await Task.Run(async () =>
          {
              await Task.Delay(2000);
    
              await dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
              {
                  throw new NotImplementedException("This exception also terminate the app.");
              });
          });
    
    }
