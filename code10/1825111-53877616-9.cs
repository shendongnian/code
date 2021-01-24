    class MainClass
    {
        public static void Main(string[] args)
        {
            var x = new MyType { MyString = "New text" };
            var y = Console.ReadKey();
        }
    }
    public class MyType
    {
        public MyType()
        {
            Console.WriteLine($"Constructor: {MyString}");
            Task.Run(() => Console.WriteLine($"Task: {MyString}"));
        }
        public string MyString { get; set; } = "Default text";
    }
