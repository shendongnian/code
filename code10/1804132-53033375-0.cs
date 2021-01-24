                using (var bc = new BlockingCollection<string>(new ConcurrentQueue<string>(chuncks)))
                {
                    //Signal complete adding
                    bc.CompleteAdding();
                    var collection = bc.GetConsumingEnumerable();
                    Parallel.ForEach(collection, (row, _, index) =>
                    {
                        ProcessText(row);
                    });
                    return String.Join(String.Empty, collection);
                }
