    using System.Reflection;
    
    namespace Test2
    {
        public class Class1
        {
            public string CallMe()
            {
                return Assembly.GetExecutingAssembly().FullName;
            }
        }
    }
