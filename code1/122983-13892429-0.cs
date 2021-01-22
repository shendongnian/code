    public abstract class Base
    {
       public virtual void PartialImplementation()
       {
          // partial implementation
       }
    }
    public sealed class Sub : Base
    {
       public override void PartialImplementation()
       {
          base.PartialImplementation();
          // rest of implementation
       }
    }
