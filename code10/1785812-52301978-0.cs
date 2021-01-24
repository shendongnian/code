    public int CountComplicatedData<TEntity>(Func<TEntity,bool> condition) {
        return database
            .Set<TEntity>()
            .SqlQuery("SELECT * FROM <Complicated Query Here>")
            .Count(condition);
    }
