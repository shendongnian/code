    class BaseClass{
      public Log log = Utils.CreateLog();
    }
    class DerivedClass : BaseClass {
      public DerivedClass() {
        log = Utils.CreateLog();
      }
    }
    
