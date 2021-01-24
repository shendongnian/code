    class Program
    {
        private static Dictionary<string, Delegate> methods = new Dictionary<string, Delegate>();
        static void Main(string[] args)
        {
            methods.Add("Test1", new Action<string>(str => { Console.WriteLine(str); }));
            methods.Add("Test2", new Func<string, bool>(str => { return string.IsNullOrEmpty(str); }));
        }
    }
