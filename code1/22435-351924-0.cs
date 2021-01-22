    public abstract class BaseDomainObject{
      public BaseDomainObject() { }
      
      private int _id;
      public virtual int Id { get { return _id; } set { _id = value; } }
    }
    
    public SomeDomainObject : BaseDomainObject{
      ...
    }
