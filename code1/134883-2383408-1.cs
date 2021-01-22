    class Test : DynamicObject {
      public void Foo() {
        Console.WriteLine("Foo called");
      }
      protect void Bar() {
        Console.WriteLine("Bar called");
      }
    
      public override bool TryInvokeMember
          (InvokeMemberBinder binder, object[] args, out object result) {
        Console.WriteLine("Calling: " + binder.Name);
        return base.TryInvokeMember(binder, args, out result);
      }
    }
    
