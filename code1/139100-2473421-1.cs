    public class Foo
    {
        ...
        public Object Bar(object arg)
        {
           // this function will run on a separate thread.
        }
    }
 
    ...
    // this delegate is used to Invoke Bar on Foo in separate thread, this must
    // take the same arguments and return the same value as the Bar method of Foo
    public delegate object FooBarCaller (object arg);
    ...
    // call this on the main thread to invoke Foo.Bar on a background thread
    //
    public IAsyncResult BeginFooBar(AsyncCallback callback, object arg)
    {
       Foo foo = new Foo();
       FooBarCaller caller = new FooBarCaller (foo.Bar);
       return caller.BeginInvoke (arg);
    }
