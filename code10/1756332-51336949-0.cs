     CancellationTokenSource tokenSource;
    
            private void CancelSendMessageTask()
            {
                tokenSource?.Cancel();
            }
    
            private void StartTimer()
            {
                int SecondsToWait = 90;
                tokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(SecondsToWait));
    
                Task.Delay(TimeSpan.FromSeconds(SecondsToWait), tokenSource.Token).ContinueWith((t) =>
                {
                    if (t.IsCanceled) return;
                    SendSMS();
                });
            }
