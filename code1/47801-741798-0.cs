    public class Foo {
      private ComFoo _com;
      private SynchronizationContext _context;
      public void Bar() { 
        _context.Send(notUsed => _com.Bar(););
      }
    }
