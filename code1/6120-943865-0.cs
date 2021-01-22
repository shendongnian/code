    using System.Linq;
        
    ...
        
    foreach(ISomethingable s in collection.OfType<ISomethingable>())
    {
      s.DoSomething();
    }
