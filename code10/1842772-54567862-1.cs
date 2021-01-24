    private CancellationTokenSource _cs;
    private int _timerMinute =0;
    
    private async void Label1_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
       _cs?.Cancel();
       _cs?.Dispose();
       _cs = new CancellationTokenSource();
       try
       {
          while (!_cs.Token.IsCancellationRequested)
          {
             await Task.Delay(200, _cs.Token);
    
             Label1.Content = $"{++_timerMinute:00}";
          }
       }
       catch (OperationCanceledException) {}
    }
    private void Label1_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
    {
       _cs?.Cancel();
       _cs?.Dispose();
    }
