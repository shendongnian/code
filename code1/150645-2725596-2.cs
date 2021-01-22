    class Program
    {
        private static readonly Dictionary<string, object> ViewState = new Dictionary<string, object>();
        private static bool SomeBool;
        static void Main(string[] args)
        {
            ViewState["any"] = (bool?)null; SomeBool = true; Console.WriteLine(Any);
            ViewState["any"] = (bool?)false; SomeBool = true; Console.WriteLine(Any);
            ViewState["any"] = (bool?)true; SomeBool = true; Console.WriteLine(Any);
            ViewState["any"] = (bool?)null; SomeBool = false; Console.WriteLine(Any);
            ViewState["any"] = (bool?)false; SomeBool = false; Console.WriteLine(Any);
            ViewState["any"] = (bool?)true; SomeBool = false; Console.WriteLine(Any);
            Console.ReadLine();
        }
        static bool? Any
        {
            get
            {
                return ((ViewState["any"] as bool?) ?? false) && SomeBool;
            }
        }
    }
