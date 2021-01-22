    internal static class TypeHelper
    {
        private const char genericSpecialChar = '`';
        private const string genericSeparator = ", ";
        public static string GetCleanName(this Type t)
        {
            string name = t.Name;
            if (t.IsGenericType)
            {
                name = name.Remove(name.IndexOf(genericSpecialChar));
            }
            return name;
        }
        public static string GetCodeDefinition(this Type t)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0}.{1}", t.Namespace, t.GetCleanName());
            if (t.IsGenericType)
            {
                var names = from ga in t.GetGenericArguments()
                            select GetCodeDefinition(ga);
                sb.Append("<");
                sb.Append(string.Join(genericSeparator, names.ToArray()));
                sb.Append(">");
            }
            return sb.ToString();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            object[] testCases = { 
                                    new Dictionary<string, DateTime>(),
                                    new List<int>(),
                                    new List<List<int>>(),
                                    0
                                };
            Type t = testCases[0].GetType();
            string text = t.GetCodeDefinition();
            Console.WriteLine(text);
        }
    }
