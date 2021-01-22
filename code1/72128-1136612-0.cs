    class Program
    {
        static void Main(string[] args)
        {
            List<Assembly> assembliesToSearch = new List<Assembly>();
            // Add the assemblies that you want to search here:
            assembliesToSearch.Add(Assembly.Load("mscorlib")); // sample assembly, you might need Assembly.GetExecutingAssembly
            foreach (Assembly assembly in assembliesToSearch)
            {
                var typesForThatTheFunctionReturnedTrue = assembly.GetTypes().Where(type => MyFunction(type) == true);
                foreach (Type type in typesForThatTheFunctionReturnedTrue)
                {
                    Console.WriteLine(type.Name);
                }
            }
        }
        static bool MyFunction(Type t)
        {
            // Put your logic here
            return true;
        }
    }
