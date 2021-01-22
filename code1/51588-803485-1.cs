    TheOtherClass toc;
    //...
    Action factoryMethod = myFactory.SetFactory;
    toc.SetFactoryMethod(factoryMethod);
    
    
    class TheOtherClass
    {
       public void SetFactory(Action factoryMethod)
       {
          // set here
       }
    
    }
