    public abstract class ValidationObjectContext : ObjectContext{
        ...
        
        public override int SaveChanges(SaveOptions options){
            ValidateEntities();
            return base.SaveChanges(options);
        }
    
    }
