    internal sealed class Foo
    {
        private Int32 bar = 42;
    
        private void Bar()
        {
            // Uncommenting the following line will change the
            // semantics of the method and probably introduce
            // a bug.  
            //var bar = 123;
    
            Console.WriteLine(bar);
    
            // This statement will not be affected.
            Console.WriteLine(this.bar);
        }
    }
