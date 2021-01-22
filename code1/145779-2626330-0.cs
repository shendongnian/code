    public static Trade FindTradeByTradeTagCompiled(MyEntities entities, int tag)
    {
        IQueryable<Trade> tradeQuery = mCompiledFindTradeQuery(entities, tag);
        return tradeQuery.AsEnumerable().FirstOrDefault();
    }
