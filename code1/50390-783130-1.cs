    using System;
    using System.Reflection;
    
    delegate string MyDelegate();
    
    public class Dummy
    {
        public override string ToString()
        {
            return "Hi there";
        }
    }
    
    public class Test
    {
        static MyDelegate GetByName(object target, string methodName)
        {
            MethodInfo method = target.GetType()
                .GetMethod(methodName, 
                           BindingFlags.Public 
                           | BindingFlags.Instance 
                           | BindingFlags.FlattenHierarchy);
            
            // Insert appropriate check for method == null here
            return (MyDelegate) Delegate.CreateDelegate
                (typeof(MyDelegate), target, method);
        }
        
        static void Main()
        {
            Dummy dummy = new Dummy();
            MyDelegate del = GetByName(dummy, "ToString");
            
            Console.WriteLine(del());
        }
    }
