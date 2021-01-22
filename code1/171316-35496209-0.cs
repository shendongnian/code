                var batchSize = dataAsIEnumerable.Count / BatchSize;
                
                // not enought items, create at least one batch
                if (batchSize < 1)
                    batchSize = 1;
                var dataAsList = dataAsIEnumerable.ToList();
                var batchAsSplit = new List<List<Model>>();
                for (int j = 0; j < batchSize; j++)
                {
                    batchAsSplit.Add(dataAsList.GetRange(j * BatchSize, (dataAsList.Count - (j * BatchSize)) - BatchSize > 0 ? BatchSize : dataAsList.Count - (j * BatchSize)));
                }
                Parallel.ForEach(batchAsSplit, item =>
                {
                    lock (MyContent)
                        MyContent.InsertBulk(item);
                });
