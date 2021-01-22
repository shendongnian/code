    class Program
    {
        static void Main(string[] args)
        {
            // display the custom attributes on our method
            Type t = typeof(Program);
            foreach (object obj in t.GetMethod("Method").GetCustomAttributes(false))
            {
                Console.WriteLine(obj.GetType().ToString());
            }
            // display the custom attributes on our delegate
            Action d = new Action(Method);
            foreach (object obj in d.Method.GetCustomAttributes(false))
            {
                Console.WriteLine(obj.GetType().ToString());
            }
        }
        public Program()
        {
        }
        [CustomAttr]
        public static void Method()
        {
        }
    }
    public class CustomAttrAttribute : Attribute
    {
    }
