    class Program
    {
        static void Main(string[] args)
        {
            double alpha = Math.Sin(1.0);
            int beta = alpha.CompareTo(1.0);
            Console.WriteLine("{0} {1}", alpha, beta);
            double gamma = (double)CallClassMethod("System.Math.Sin", 1.0);
            int delta = (int)CallInstanceMethod(gamma, "CompareTo", 1.0);
            Console.WriteLine("{0} {1}", gamma, delta);
            string a = "abc";
            string x = "xyz";
            string r = String.Join(",", a, x);
            string s = r.Replace(",", ";");
            Console.WriteLine("{0} {1}", r, s);
            string t = (string)CallClassMethod("System.String.Join", ",", new String[] { a, x }); // Join takes varargs
            string u = (string)CallInstanceMethod(t, "Replace", ",", ";");
            Console.WriteLine("{0} {1}", t, u);
            Console.ReadKey();
        }
        static object CallClassMethod(string command, params object[] args)
        {
            Regex regex = new Regex(@"(.*)\.(\w*)");
            Match match = regex.Match(command);
            string className = match.Groups[1].Value;
            string methodName = match.Groups[2].Value;
            Type type = Type.GetType(className);
            List<Type> argTypeList = new List<Type>();
            foreach (object arg in args) { argTypeList.Add(arg.GetType()); }
            Type[] argTypes = argTypeList.ToArray();
            MethodInfo method = type.GetMethod(methodName, argTypes, null);
            return method.Invoke(null, args);
        }
        static object CallInstanceMethod(object instance, string methodName, params object[] args)
        {
            Type type = instance.GetType();
            List<Type> argTypeList = new List<Type>();
            foreach (object arg in args) { argTypeList.Add(arg.GetType()); }
            Type[] argTypes = argTypeList.ToArray();
            MethodInfo method = type.GetMethod(methodName, argTypes, null);
            return method.Invoke(instance, args);
        }
    }
