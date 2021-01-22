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
            int result = TestPrivateConstructor.sum(10, 15);
            // TestPrivateConstructor objClass = new TestPrivateConstructor(); // Will throw the error. We cann't create object of this class
        }
    }
