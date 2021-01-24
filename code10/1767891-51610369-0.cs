    using System;
    using System.Reflection;
    
    class Foo
    {
    
        public int Bar(string whatever) => whatever.Length;
    }
    
    delegate int AbilityAction(string name);
    static class Program
    {
    
    
        static void Main(string[] args)
        {
            var foo = new Foo();
            var action = GetMethodInClass<AbilityAction>(nameof(foo.Bar), foo);
    
            int x = action("abc");
            Console.WriteLine(x); // 3
        }
    
        public static D GetMethodInClass<D>(string methodName, object target) where D : Delegate
        {
            var mi = target.GetType().GetMethod(methodName,
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            return (D)Delegate.CreateDelegate(typeof(D), target, mi);
        }
    }
