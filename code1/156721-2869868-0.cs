    //By the name of the example, I can assume that MyDisposableClass 
    //implements IDisposable
    using (MyDisposableClass something = new MyDisposableClass())
    {
       //Assuming the example code compiles, then the return value of MethodA
       //implemented IDisposable, too.
       using(something.MethodA())
       {
 
       };
    }
