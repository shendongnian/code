        public class Program
    {
        static void Main(string[] args)
        {
            MethodInfo info1 = typeof(ISomeInterface<>).GetMethod("func");
            MethodInfo info2 = typeof(MyStringCollection).GetMethod("func");
            MethodInfo info3 = typeof(MyProgramCollection).GetMethod("func");
            MethodInfo info4 = typeof(MyXCollection).GetMethod("func");
            if (CheckGenericMethod(info1)) Console.WriteLine("true");
            if (CheckGenericMethod(info2)) Console.WriteLine("true");
            if (CheckGenericMethod(info3)) Console.WriteLine("true");
            if (CheckGenericMethod(info4)) Console.WriteLine("false");
            Console.ReadKey();
        }
        public static bool CheckGenericMethod(MethodInfo methodInfo)
        {
            bool areSimilarMethods = false;
            MethodInfo methodToCompare = typeof(ISomeInterface<>).GetMethod("func");
            Type interfaceInfo = methodInfo.DeclaringType.GetInterface(methodToCompare.DeclaringType.FullName);
            if (interfaceInfo != null)
                areSimilarMethods = (methodToCompare.Name.Equals(methodInfo.Name)
                && interfaceInfo.FullName.Contains(methodToCompare.DeclaringType.FullName));
            else
            {
                areSimilarMethods = methodToCompare.DeclaringType.GetType().Equals(methodInfo.DeclaringType.GetType());
            }
            return areSimilarMethods;
        }
    }
    public interface ISomeInterface<T> where T : class
    {
        T func(T s);
    }
    public class MyStringCollection : ISomeInterface<string>
    {
        public string func(string s)
        {
            return s;
        }
    }
    public class MyProgramCollection : ISomeInterface<Program>
    {
        public Program func(Program s)
        {
            return s;
        }
    }
    public class MyXCollection
    {
        public int func(int s)
        {
            return s;
        }
    }
