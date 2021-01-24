     private async void Search_Button_ClickAsync(object sender, EventArgs e)
        {
          cToken = cTokenSource.Token;
          await (Task.Factory.StartNew(() =>
                   {
    
                   for(int i=0;i<yourtaskcount;i++)
                   { 
                     if (cToken.IsCancellationRequested)
                       throw new OperationCanceledException();
                       
                      //long work
                   cToken));
        }
        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
          if (e.KeyCode == Keys.Escape)
          {
            tokenSource.Cancel();
          }
        }
