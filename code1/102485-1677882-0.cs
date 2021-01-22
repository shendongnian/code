    class ClassA {
      public void FunctionClassA(...) { ... }
      public void FunctionClassB(...) { ... }
    }
    
    class ClassX : ClassB {
      private ClassA classa;
      public ClassX() {
         classa = new ClassA();
      }
      public void FunctionClassA(...) { classa.FunctionClassA(...); }
    }
