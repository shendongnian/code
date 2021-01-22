    public abstract class ObjectModelBase<BllClass, EntityClass>
    {
        // ... same basic code here...
    
        // supplied by your derivatives...
        protected abstract Func<IQueryable<EntityClass>> GetEntitySet { get; };
        protected abstract Func<Guid,Func<EntityClass,bool>> KeySelector { get; }
      
        public BllClass GetById(Guid id)
        {
            using (db = new DataStoreEntities1())
            {
                EntityClass result = (EntityClass)((object)
                     GetEntitySet()
                         .Where( KeySelector( id ) )
                         .First();
                return MapEntityToBLL(result);
            }
        }
    }
    
    public class OM_Customer : ObjectModelBase<ICustomer,Entity.Customer>
    {
        protected abstract Func<IQueryable<Entity.Customer>> GetEntitySet
        { 
            get { return db.CustomerSet; }
        }
    
        protected abstract Func<Guid,Func<Entity.Customer,bool>> KeySelector
        {
            get { return (g => (e => e.Id == g)); }
        }
    }
