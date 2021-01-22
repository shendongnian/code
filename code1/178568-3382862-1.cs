    //This is pseudo code but comes close at the important parts
    public class Class1
        {
            //The actual type is different from this
            private static Func<int, int> myMethod = AnonymousFunction; 
    
            public void f()
            {
                myMethod(0);
            }
    
            private static int AnonymousFunction(int i)
            {
                return 1;
            }
        }
