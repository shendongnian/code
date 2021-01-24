      IObservable<IList<Data>> GetData(int args)
            {
                var result = new Subject<IList<Data>>();
    
                Task.Run(async () =>
                {
                    try
                    {
                        var formCache = await GetFromCache(args);
    
                        result.OnNext(fromCache);
    
                        while (moreBatches)
                        {
                            result.OnNext(GetNextBatch(args));
                        }
    
                        result.OnCompleted();
                    }
                    catch (Exception e)
                    {
                        result.OnError(e);
                    }
                });
    
                return result;
            }
