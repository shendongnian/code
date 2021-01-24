    public async Task<bool> Save(List<FoundOn> foundOns)
    {
        try
        {
            var batches = new List<TableBatchOperation>();
            List<List<FoundOn>> groups = foundOns.GroupBy(x => x.SourceURL.ToLower()).Select(s => s.ToList()).ToList();
            foreach (List<FoundOn> sourceRecords in groups)
            {
                var rowId = 0;
                List<PageLinkTableEntity> records = new PageLinkMapper().MapTo(sourceRecords);
                for (var i = 0; i < records.Count; i += TableConstants.TableServiceBatchMaximumOperations)
                {
                    var batchOperation = new TableBatchOperation();
                    List<PageLinkTableEntity> batchItems = records.Skip(i).Take(TableConstants.TableServiceBatchMaximumOperations).ToList();
                    foreach (PageLinkTableEntity item in batchItems)
                    {
                        item.RowKey = $"{item.RowKey}|{rowId}";
                        batchOperation.InsertOrReplace(item);
                        rowId++;
                    }
                    if (batchOperation.Count > 0)
                    {
                        //This line of code takes around 1 second to execute
                        batches.Add(batchOperation);
                    }
                }
                if (batches.Count > 20)
                {
                    //This line of code takes 0ms to execute, as there are never any uncompleted tasks
                    await Task.WhenAll(batches.Select(c => _table.ExecuteBatchAsync(c)));
                    batches.Clear();
                }
            }
            //This line of code takes 0ms to execute, as there are never any uncompleted tasks
            await Task.WhenAll(batches.Select(c => _table.ExecuteBatchAsync(c)));
            return true;
        }
        catch (Exception ex)
        {
            _log.Error($"PageLinkRepository: Unable to save found on.  Error: { ex.Message }");
            throw;
        }
    }
