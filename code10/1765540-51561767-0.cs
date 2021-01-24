    private async Task tf(CancellationToken token , string list)
    {
            try
            {
                await Task.Run(() =>
                {
                    if (token.IsCancellationRequested)
                    {
                        MessageBox.Show("Stopped", "Operation Aborted");
                        token.ThrowIfCancellationRequested();
                        cts = new CancellationTokenSource();
                    } 
                    // do something
                }, token);
           }catch{}
    }
