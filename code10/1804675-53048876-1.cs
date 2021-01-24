    var cancellationTokenSource = new CancellationTokenSource();
    var t = Task.Factory.StartNew(() =>
            {
                // Your code here 
            }, cancellationTokenSource.Token).ContinueWith(task =>
              {
                  if (!task.IsCompleted || task.IsFaulted)
                  {
                      // log error
                  }
              }, cancellationTokenSource.Token);
