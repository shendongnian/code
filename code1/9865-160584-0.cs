    namespace GenericCount
    {
        class Program
        {
            static int Count1<T>(IEnumerable<T> a)
            {
                return a.Count();
            }
            static void Main(string[] args)
            {
                List<string> mystring = new List<string>()
            {
                "rob","tx"
            };
                int count = Count1(mystring);
                 Console.WriteLine(count.ToString());
            }
        }
    }
