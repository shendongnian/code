    public namespace Entities.Eager
    {
    public static class EagerExtensions
    {
      public static EagerContext AsEager(this TestObjectContext source)
      {
        return new EagerContext(source);
      }
    }
    
    public class EagerContext
    {
      TestObjectContext _context;
      public EagerContext(TestObjectContext context)
      {
        _context = context;
      }
    
      public IQueryable<TestEntity> TestEntity
      {
        get{
          return _context.TestEntity.Include(....
        }
      }
    }
    
    }
