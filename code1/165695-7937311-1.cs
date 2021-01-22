    [AttributeUsage(AttributeTargets.Method, Inherited=false)]
    public class MyAttribute : Attribute { }
    class BaseClass
    {
        [My] // MyAttribute applied to base class
        public virtual void Method1() { }
    }
    class DerivatedClass : BaseClass
    {
        // MyAttribute not applied to derivate class
        public override void Method1() { }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            var attributes = typeof(DerivatedClass)
                .GetMethod("Method1")
                .GetCustomAttributes(true);
            foreach (var attr in attributes)
            {
                Console.Write(attr.ToString());
            }
        }
    } 
