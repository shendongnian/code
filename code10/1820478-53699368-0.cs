    private async void Form1_Load(object sender, EventArgs e)
    {
        await Task.Factory.StartNew(() =>
        {
          //Your code here
        },  CancellationToken.None, TaskCreationOptions.None,  TaskScheduler.FromCurrentSynchronizationContext());
    }
