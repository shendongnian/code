    public interface IFooRepository
    {
         Foo Get(Guid guid);
    }
    
    public class FooRepository : IFooRepository
    {
         public Foo Get(Guid guid)
         {
             //... DB voodoo
             return foo;
         }
    }
