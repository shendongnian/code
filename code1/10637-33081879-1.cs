    class BaseClass {
      protected void DoStuff();
    }
    
    abstract class First : IFirst {
      public void FirstMethod() { DoStuff(); DoSubClassStuff(); }
      protected abstract void DoStuff(); // base class reference in MI
      protected abstract void DoSubClassStuff(); // sub class responsibility
    }
