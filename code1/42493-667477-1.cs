    int (*MyFunc)() = MyFunc_Default;
    
    int MyFunc_SomeFunctionality()
    {
      // if(SomeFunctionalityCheck())
      ..
    }
    
    int MyFunc_Default()
    {
      // else
      ...
    }
    
    int MyFuncInit()
    {
      if(SomeFunctionalityCheck()) MyFunc = MyFunc_SomeFunctionality;
    }
