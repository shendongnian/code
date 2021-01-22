    namespace Microsoft.Sample
    {
        using Guid = System.Guid;
        public class Guid
        {
            public Guid(string s)
            {
            }
        }
    
        public class Program
        {
            public static void Main(string[] args)
            {
                Guid g = new Guid("hello");
            }
        }
    }
