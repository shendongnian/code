    namespace FakesExample
    {
        public class MyStaticClass
        {
            public static string GetText(string name)
            {
                throw new NullReferenceException();
            }
        }
    }
