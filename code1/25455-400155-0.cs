    var myClass = new MyClass();
    myClass.BeginDoSomething(
        asyncResult => {
                           using (myClass)
                           {
                               myClass.EndDoSomething(asyncResult);
                           }
                       },
        null);        
