    public abstract class BaseClass
    {
        protected virtual void DeletePersonCore(Guid id)
        {
            //shared code
        }
        
        public void DeletePerson(Guid id)
        {
            //chain it to the core
            DeletePersonCore(id);
        }
    }
    
    public class DerivedClass : BaseClass
    {
        protected override void DeletePersonCore(Guid id)
        {
            //do some polymorphistic stuff
            
            base.DeletePersonCore(id);
        }
    }
    
    public class UsageClass
    {
        public void Delete()
        {
            DerivedClass dc = new DerivedClass();
    
            dc.DeletePerson(Guid.NewGuid());
        }
    }
