    interface IDataContext, IDisposable
    {
        void AddObject(string entitySetName, object entity);
        void Attach(IEntityWithKey entity);
        void Detach(object entity);
        void DeleteObject(object entity);
        int SaveChanges();
        int SaveChanges(bool acceptChangesDuringSave);
        int SaveChanges(SaveOptions options);
    
        // Any other members you wish to be mockable
    }
    
    class DataContext: ObjectContext, IDataContext
    {
        // nothing here
    }
