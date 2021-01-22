    using System.Collections.Specialized;
    
    namespace MyProject.Util
    {
        class Program
        {
            static void Main(string[] args)
            {
                var nvc = new NameValueCollection();
                nvc.Get(  )
            }
        }
    }
    
    
    namespace MyProject.Util
    {
        public static class Extensions
        {
            public static string Get(
                 this NameValueCollection me,
                 string key,
                 string def
            )
            {
                return me[key] ?? def;
            }
        }
    }
