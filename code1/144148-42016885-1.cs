    Purpose to create the private constructor within a class
    
     1. To restrict a class being inherited.  
     2. Restrict a class being instantiate or creating multiple instance/object. 
     3. To achieve the singleton design pattern.
    Example below.
    public class TestPrivateConstructor
    {
        private TestPrivateConstructor()
        {  }
         public static int sum(int a , int b)
        {
            return a + b;
        }
    }
    
     class Program
        {
            static void Main(string[] args)
            {
                // calling the private constructor using class name directly 
                 int result = TestPrivate`enter code here`Constructor.sum(10, 15);
                // TestPrivateConstructor objClass = new TestPrivateConstructor(); // Will throw the error. We cann't create object of this class
    }
    }
