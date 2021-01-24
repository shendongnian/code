    // avoid 'async void' almost everywhere else. Ok for an event handler
    private async void HandleOnKeyDown(object sender, KeyEventArgs e)
    {
      try  // async void needs to do its own error handling 
      {    
            switch (e.Key)
            {
                case Key.Escape:
                    ButtonStop.Background = ...;
                    // sandwich StopButton() in case it takes some time too   
                    var waitTask = Task.Delay(250);  
                    StopButton();
                    await waitTask; 
                    ButtonStop.ClearValue(BackgroundProperty);
                    break;
            }
       
      }
      catch(Exception e)
      {
         // report it
      }
      // general cleanup & restore
      
    }
