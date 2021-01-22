    namespace ConsoleApplication4983
    {
        public class MyClass
        {
            static void Main()
            {
                var c = new MyClass();
                c.DoSomething(ProcessingMethod.Sequential);
                c.DoSomething(ProcessingMethod.Random);
            }
    
            public void DoSomething(ProcessingMethod method)
            {
                if (method == ProcessingMethod.Sequential)
                {
                    // do something sequential
                }
                else if (method == ProcessingMethod.Random)
                {
                    // do something random
                }
            }
        }
    
        public enum ProcessingMethod
        {
            Sequential,
            Random
        }
    }
