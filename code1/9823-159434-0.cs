    public class BaseClassProxy : BaseClass 
    {
       public BaseClass BaseClass { get; private set; }
    
       public virtual int MethodINeedToOverride(){}
       public virtual string PropertyINeedToOverride() { get; protected set; }
    }
