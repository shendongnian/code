    class ClassProxy: A { //inherits class type
      
      Proxy(): base() { ... }
    
      public override void foo(){
        InvokeInterceptors("foo");
    
        //execution gets here when calling 'invocation.Proceed()' 
        //from the interceptor
    
        base.foo();  //pass the execution to the base class 
        
      }
      public void bar(){
        InvokeInterceptors("bar");
        base.bar();
      }
    }
