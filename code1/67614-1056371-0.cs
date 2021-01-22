     private void CheckWebservice(string data)
     {
          WebService.Server server = new WebService.server();
          server.methodCompleted += server_methodCompleted;
          server.methodAsync(data);
     }
     private void server_methodCompleted(object sender, methodCompletedEventArgs e)
     {
          if (e.Error != null)
               if (MessageBox.Show("Error", "Error", MessageBoxButtons.AbortRetryIgore) == DialogResult.Retry)
               {
                    // call method to retry
               }
          else
          {
               if (e.Result == "OK") { // Great! }
          }
     }
