    class Program
        {
            static void Main(string[] args)
            {
                Type type = typeof(MyReflectionClass);
                MethodInfo method = type.GetMethod("MyMethod");
                MyReflectionClass c = new MyReflectionClass();
                string result = (string)method.Invoke(c, null);
                Console.WriteLine(result);
    
            }
        }
    
        public class MyReflectionClass
        {
            public string MyMethod()
            {
                return DateTime.Now.ToString();
            }
        }
