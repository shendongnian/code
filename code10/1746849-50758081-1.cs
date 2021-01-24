    public class Object
    {
        public string Name { get; set; }
    }
    public class TestConsole
    {
        public static void Main(string[] args)
        {
            Object fakeObject = new Object(); // -> Custom Object class
            object realDeal = new object();   // -> System.Object
            
            string name = fakeObject.Name    // OK
            name = realDeal.Name             // NOT OK
        }
    }
