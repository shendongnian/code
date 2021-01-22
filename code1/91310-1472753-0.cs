    public interface IRepository
    {
        void Save<ENTITY>(ENTITY entity)
            where ENTITY : Entity;
        void Delete<ENTITY>(ENTITY entity)
            where ENTITY : Entity;
        ENTITY Load<ENTITY>(int id)
            where ENTITY : Entity;
        IQueryable<ENTITY> Query<ENTITY>()
            where ENTITY : Entity;
        IList<ENTITY> GetAll<ENTITY>()
            where ENTITY : Entity;
        
        IQueryable<ENTITY> Query<ENTITY>(IDomainQuery<ENTITY> whereQuery)
            where ENTITY : Entity;
        ENTITY Get<ENTITY>(int id) where ENTITY : Entity;
        IList<ENTITY> GetObjectsForIds<ENTITY>(string ids) where ENTITY : Entity;
        void Flush();
    }
