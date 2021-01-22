    TheOtherClass toc;
    //...
    Action factoryMethod = myFactory.GetInstance;
    toc.SetFactoryMethod(factoryMethod);
    
    
    class TheOtherClass
    {
       public void SetFactoryMethod(Action factoryMethod)
       {
          // set here
       }
    
    }
