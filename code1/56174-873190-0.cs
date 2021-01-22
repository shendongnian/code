    using System;
    using System.Reflection;
    using System.Reflection.Emit;
    static class Program {
        static void Main() {
            MethodInfo bar = typeof(Foo).GetMethod("Bar",
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            var method = new DynamicMethod("FooBar", null, new[] {typeof(Foo)});
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.EmitCall(OpCodes.Callvirt, bar, null);
            il.Emit(OpCodes.Ret);
    
            Action<Foo> action = (Action<Foo>) method.CreateDelegate(typeof(Action<Foo>));
            Foo foo = new Foo();
            Console.WriteLine("Created method etc");
            action(foo); // MethodAccessException
        }
    }
    
    public class Foo {
        private void Bar() {
            Console.WriteLine("hi");
        }
    }
