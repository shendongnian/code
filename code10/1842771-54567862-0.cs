    private CancellationTokenSource _cs;
    private int _timerMinute =0;
    
    public async void Start(CancellationToken token)
    {
       try
       {
          while (!token.IsCancellationRequested)
          {
             await Task.Delay(200, token); 
             Label1.Content = $"{++_timerMinute:00}";
          }
       }
       catch (OperationCanceledException e) {}
    }
    
    private void Label1_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
       _cs?.Cancel();
       _cs?.Dispose();
       _cs = new CancellationTokenSource();
       Start(_cs.Token);
    }
    
    private void Label1_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
    {
       _cs?.Cancel();
       _cs?.Dispose();
    }
