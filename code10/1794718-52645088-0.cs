            var token = new CancellationTokenSource();
            _tokens.Add(token);
            await Task.Run(() =>
            {
                foreach (var item in list)
                {
                    if (token.Token.IsCancellationRequested)
                        break;
                    Dispatcher.Invoke(() => Collection.Add(item));
                    RaisePropertyChanged("Collection");
                    Thread.Sleep(10);
                }
                if (token.Token.IsCancellationRequested)
                    Dispatcher.Invoke(() =>
                    {
                        foreach (var item in list)
                            Collection.Remove(item);
                        RaisePropertyChanged("Collection");
                    });
                _tokens.Remove(token);
            }, token.Token);
            
