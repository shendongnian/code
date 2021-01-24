     public IEnumerable<typeEntity> Get<typeEntity>(Expression<Func<typeEntity, bool>> newObjectEntity,int page, int rowsByPage, string include) where typeEntity : class
        {
           List<typeEntity> Result = null;
                Result = Context.Set<typeEntity>().Where(newObjectEntity).include(include).OrderBy(m => true).Skip<typeEntity>(5 * (page - 1)).Take<typeEntity>(rowsByPage).ToList<typeEntity>();
            return Result;
        }
