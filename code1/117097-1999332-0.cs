    interface I {
      public String getName();
      public void doSomething();
    }
    
    class A implements I {
      public String getName() { return "one"; }
      public void doSomething() { ...; }
    }
    
    class B implements I {
      public String getName() { return "two"; }
      public void doSomething() { ...; }
    }
  
