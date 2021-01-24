    private async void OnKeyDownHandler(object sender, KeyEventArgs e)
    {
      try  // async void needs error handling 
      {
    
            switch (e.Key)
            {
                case Key.Escape:
                    ButtonStop.Background = ...;
                    var wait = Task.Delay(250);  // in case StopButton does take some time
                    StopButton();
                    await wait;             
                    ButtonStop.ClearValue(BackgroundProperty);
                    break;
            }
    
    
      }
      catch()
      {
         // report it
      }
    }
