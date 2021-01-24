       Public class myClassNameTwo : Hub
       {
          private readonly AssetsBroadcaster _broadcaster;
          private readonly myClassName _myClassName;
    
          public myClassNameTwo(AssetsBroadcaster broadcaster,
                    myClassName myClassName)
          {
            _broadcaster = broadcaster;     
            _myClassName = myClassName;   
          }
    
          public async Task DoSomething(...) 
          {    
            await _myClassName.FirstMethod(...)
          }
      }
