    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<MyObject> myList = new List<MyObject>();
    
                MyFunction(myList);
                MyFunction((object)myList);
                MyFunction(myList.Cast<object>().ToList());
                MyFunction(myList.Cast<object>());
            }
    
    
            public static void MyFunction(List<object> blah)
            {
                Console.WriteLine(blah.GetType().ToString());
            }
    
            public static void MyFunction(IEnumerable<object> blah)
            {
                Console.WriteLine(blah.GetType().ToString());
            }
    
            public static void MyFunction(object blah) 
            {
                Console.WriteLine(blah.GetType().ToString());
            }
        }
    
    
        public class MyObject { }
    }
