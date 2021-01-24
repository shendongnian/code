    public class Page1
    {
        public Page1()
        {
            new myClass("Page1.cs");
        }
    }
    public class myClass(string caller)
    {
        public myClass(string caller = "")
        {
            Console.WriteLine(caller);
            Console.ReadKey();
        }
    }
