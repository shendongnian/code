    class MyObject : DynamicObject {
      public override bool TryGetMember
          (GetMemberBinder binder, out object result) {
        string name = binder.Name;
        // set the 'result' parameter to the result of the call
        return // true to pretend that attribute called 'name' exists
      }
      public override bool TrySetMember
          (SetMemberBinder binder, object value) {
        // similar to 'TryGetMember'
      }  
    }
