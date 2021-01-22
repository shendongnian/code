    class Program
    {
        public static void GetParameterValue<T>(out T destination)
        {
            Console.WriteLine("typeof(T)=" + typeof(T).Name);
            destination = default(T);
        }
        static void Main(string[] args)
        {
            string s;
            GetParameterValue(out s);
            int i;
            GetParameterValue(out i);
        }
    }
