    private async void OnFormLoading(object sender, ...)
    {
         // show an intro screen while doing initializations:
         using (var startupForm = new FormStartup()
         {
              var dlgResult = startupForm.ShowDialog(this);
              if (dlgResult == DialogResult.Cancel)
              {
                   // operator cancelled starting up:
                   this.Close();
              }
              else
              {
                   // continue starting up
              }
        }
    }
 
         }
    }
    class FormStartup
    {
        public void FormStartup() {...}
        private async void OnFormLoading(object sender, ...)
        {
            Task delayTask = Task.Delay(TimeSpan.FromSeconds(5));
            DoOtherInitializations();
            await delayTask;
        }
    }
             
