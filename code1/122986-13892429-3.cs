    public abstract class Base
    {
       public void PartialImplementation()
       {
          // partial implementation
          RestOfImplementation();
       }
       // protected, since it probably wouldn't make sense to call by itself
       protected abstract void RestOfImplementation();      
    }
    public sealed class Sub : Base
    {
       protected override void RestOfImplementation()
       {
          // rest of implementation
       }
    }
