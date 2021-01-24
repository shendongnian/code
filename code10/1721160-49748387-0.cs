     // in your UI
                var result = new ObservableCollection<Data>(); // this is your list to bind to UI
    
                IsBusy = true; // indicate that work is done
                yourDataSource.GetData(2000).Subscribe(batch =>
                {
                    foreach (var d in batch)
                    {
                        result.Add(d);
                    }
                },
                    exception =>
                    {
                        Log.Error(exception);
                        IsBusy = false;
                    },
                    () =>
                    {
                        // this means done
                        IsBusy = false;
                    }
                )
    
                // or you can await the whole thing
                try
                {
                    IsBusy = true;
                    await yourDataSource.GetData(5).Do(batch =>
                    {
                        foreach (var d in batch)
                        {
                            result.Add(d);
                        }
                    });
                }
                finally
                {
                    IsBusy = false;
                }
