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
                 int abc = TestPrivateConstructor.sum(10, 15);
    }
    }
