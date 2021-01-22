    namespace Cheeso.Toys
    {
        public class Object1
        {
            public int Value1 { get; set; }
            public int Value2 { get; set; }
            public Object2 Value3 { get; set; }
        }
        public class Object2
        {
            public int Value1 { get; set; }
            public int Value2 { get; set; }
            public int Value3 { get; set; }
            public override String ToString()
            {
                return String.Format("Object2[{0},{1},{2}]", Value1, Value2, Value3);
            }
        }
        public class ReflectionInvokePropertyOnType
        {
            public static void Main(string[] args)
            {
                try
                {
                    Object1 target = new Object1
                        {
                            Value1 = 10, Value2 = 20, Value3 = new Object2
                                {
                                    Value1 = 100, Value2 = 200, Value3 = 300
                                }
                        };
                    System.Type t= target.GetType();
                    String propertyName = "Value3";
                    Object2 child = (Object2) t.InvokeMember (propertyName,
                                                              System.Reflection.BindingFlags.Public |
                                                              System.Reflection.BindingFlags.Instance  |
                                                              System.Reflection.BindingFlags.GetProperty,
                                                              null, target, new object [] {});
                    Console.WriteLine("child: {0}", child);
                }
                catch (System.Exception exc1)
                {
                    Console.WriteLine("Exception: {0}", exc1.ToString());
                }
            }
        }
    }
