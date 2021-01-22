    Main(){
   
      //proxy-ing an explicit type
      A proxy = (A) new Castle.DynamicProxy.ProxyGenerator()
                     .CreateClassProxy<A>(new Interceptor());
      proxy.foo();
    
    }
