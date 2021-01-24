    foreach (var tradeEntity in OrderEntityColection)
    {
        Parallel.ForEach(samplePriceList.Where(item=>item.MarketId == tradeEntity.MarketId && item.Audit == tradeEntity.InstructionPriceAuditId) ,new ParallelOptions {MaxDegreeOfParallelism = 8}, (price) =>
        {
             // Do whatever processing is required here
            Interlocked.Increment(ref count);
        });
    }
