    using System;
    using System.Reflection;
    class Base
    {
        public virtual void Overridden() {}
        public virtual void NotOverridden() {}
    }
    
    class Derived : Base
    {
        public override void Overridden() {}
        public virtual void NewlyDeclared() {}
    }
    
    public class Test
    {
        static void Main()
        {
            foreach (MethodInfo method in typeof(Derived).GetMethods())
            {
                Console.WriteLine("{0}: {1} {2} {3}",
                                  method.Name,
                                  method == method.GetBaseDefinition(),
                                  method.DeclaringType,
                                  method.GetBaseDefinition().DeclaringType);
            }
        }
    }
