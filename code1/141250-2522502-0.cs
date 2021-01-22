    MyClass myClass = new MyClass();
    Type myinterface = myClass.GetType()
                              .GetInterface(typeof(IMyInterface<int>).Name);
    
    Assert.That(myinterface, Is.Not.Null);
