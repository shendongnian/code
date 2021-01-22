    namespace DoctaJonez.StackOverflow
    {
        class Example
        {
            //the delegate declaration
            public delegate IEnumerable<T> GetGridDataSource<T>();
    
            //the generic method used to call the method
            public void someMethod<T>(GetGridDataSource<T> method)
            {
                method();
            }
    
            //a method to pass to "someMethod<T>"
            private IEnumerable<string> methodBeingCalled()
            {
                return Enumerable.Empty<string>();
            }
    
            //our main program look
            static void Main(string[] args)
            {
                //create a new instance of our example
                var myObject = new Example();
                //invoke the method passing the method
                myObject.someMethod<string>(myObject.methodBeingCalled);
            }
        }
    }
