    class Program
    {
        static string someKey = null;
        static void Main(string[] args)
        {
            try
            {
                object thing;
                if (SomeSeeminglyUnrelatedFunction(someKey, out thing)) Console.WriteLine("Found");
                things.TryGetValue(someKey, out thing);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace.ToString());
                throw;
            }
            Console.ReadKey();
        }
        private static Dictionary<string, object> stuff = new Dictionary<string, object>();
        private static Dictionary<string, object> things = new Dictionary<string, object>();
        private static bool SomeSeeminglyUnrelatedFunction(string key, out object item)
        {
            return stuff.TryGetValue(key, out item);
        }
    }
