    public IEnumerable<typeEntity> Get<typeEntity>(Expression<Func<typeEntity, bool>> newObjectEntity,int page, int rowsByPage) where typeEntity : class
    {
       IEnumerable<typeEntity> Result = null;
            Result = Context.Set<typeEntity>().Where(newObjectEntity).OrderBy(m => true).Skip<typeEntity>(5 * (page - 1)).Take<typeEntity>(rowsByPage);
        return Result;
    }
