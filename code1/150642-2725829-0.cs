     private void HitBall() 
     { 
         try {
             Mouse.OverrideCursor = Cursors.Wait;
             Dispatcher dispatcher = Dispatcher.CurrentDispatcher;
             Action hitOperations = () =>
             {
                 hitStation.PrepareHit(hitSpeed);
                 Thread.Wait(1000);
                 //Only needed if PlayWarning needs access to UI Thread
                 dispatcher.Invoke(() => PlayWarning());
                 hitStation.HitBall(hitSpeed);
                 dispatcher.Invoke(() => Mouse.OverrideCursor = null);
              };
              //Free the UI from work, start operations in a background thread
              hitOperations.BeginInvoke(null, null);
          }
          catch (TimeoutException ex)
          {
              MessageBox.Show("Timeout hitting ball: " + ex.Message);
          }
     }
