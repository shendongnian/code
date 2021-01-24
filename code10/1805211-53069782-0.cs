    class Program
    {
        static dynamic vars = new System.Dynamic.ExpandoObject();
        static void NewVar(string name, object value)
        {
            ((System.Dynamic.ExpandoObject)vars).TryAdd(name, value);
        }
        static void Main(string[] args)
        {
            NewVar("Hello", 213);
            var a = vars.Hello;
        }
    }
