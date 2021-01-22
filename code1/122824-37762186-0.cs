      public void ProcessContextByChunks ()
      {
            var tableName = "MyTable";
             var startTime = DateTime.Now;
            int i = 0;
             var minMaxIds = GetMinMaxIds();
            for (int fromKeyID= minMaxIds.From; fromKeyID <= minMaxIds.To; fromKeyID = fromKeyID+_chunkSize)
            {
                try
                {
                    using (var context = InitContext())
                    {   
                        var chunk = GetMyTableQuery(context).Where(r => (r.KeyID >= fromKeyID) && (r.KeyID < fromKeyID+ _chunkSize));
                        try
                        {
                            foreach (var row in chunk)
                            {
                                foundCount = UpdateRowIfNeeded(++i, row);
                            }
                            context.SaveChanges();
                        }
                        catch (Exception exc)
                        {
                            LogChunkException(i, exc);
                        }
                    }
                }
                catch (Exception exc)
                {
                    LogChunkException(i, exc);
                }
            }
            LogSummaryLine(tableName, i, foundCount, startTime);
        }
    
        private FromToRange<int> GetminMaxIds()
        {
            var minMaxIds = new FromToRange<int>();
            using (var context = InitContext())
            {
                var allRows = GetMyTableQuery(context);
                minMaxIds.From = allRows.Min(n => n.KeyID);
                minMaxIds.To = allRows.Max(n => n.KeyID);
            }
            return minMaxIds;
        }
    
        private IQueryable<MyTable> GetMyTableQuery(MyEFContext context)
        {
            return context.MyTable;
        }
    
        private  MyEFContext InitContext()
        {
            var context = new MyEFContext();
            context.Database.Connection.ConnectionString = _connectionString;
            //context.Database.Log = SqlLog;
            return context;
        }
