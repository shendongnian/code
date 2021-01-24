    namespace TestAOP
    {
        class Program
        {
            static void Main(string[] args)
            {
               var t = new Test();
    
               var x = t.TestProperty;
            
               Console.WriteLine(x);
    
               Console.Read();
            }
        }
    
        public class Test
        {
            private string _test = "InitialValue";
    
            [CustomProperty]
            public string TestProperty
            {
                get => _test;
                set => _test = value;
            }
        }
    
        [Serializable]
        public sealed class CustomPropertyAttribute : MethodInterceptionAspect
        {
            public override void OnInvoke(MethodInterceptionArgs args)
            {
               args.ReturnValue = args.Method.Name.Substring(args.Method.Name.IndexOf("_", StringComparison.Ordinal) + 1);
    
            }
        }
    }
