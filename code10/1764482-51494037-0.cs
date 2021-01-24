    public class MyAttribute : Attribute
    {
        public MyAttribute(string str)
        {
            argument = str;
        }
        private string argument;
        public string Argument { get; }
        public string AssemblyName
        {
            get
            {
                return Assembly.GetEntryAssembly().FullName;
            }
        }
    }
    [MyAttribute("Hello")]
    class Program
    {
        static void Main(string[] args)
        {
            var attr = typeof(Program).GetCustomAttribute<MyAttribute>();
            Console.WriteLine(attr.Argument);
            Console.WriteLine(attr.AssemblyName);
        }
    }
