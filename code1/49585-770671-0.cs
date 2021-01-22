    sealed class Parent : Child  {
      public override string GetName() { return "foo"; }
    }
    
    public void Test() {
      var p = new Parent();
      var name = p.GetName();
    }
