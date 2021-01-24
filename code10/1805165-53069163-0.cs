    public class Foo
    {
       var cancellationTokenSource = new CancellationTokenSource();
       var token = cancellationTokenSource.Token();
       public void Start() {
            var t = Task.Factory.StartNew(() =>
            {
                try
                {
                   await new Bot().StartAsync(token);
                }
                catch(Exception ex)
                {
                   Console.WriteLine(ex.ToString());
                }
            }, token).ContinueWith(task =>
              {
                  if (!task.IsCompleted || task.IsFaulted)
                  {
                     // Log
                  }
              }, token);
        }
        StopTask_Click(object sender, EventArgs e) 
        {
              cancellationTokenSource.Cancel();
        }
    }
    
