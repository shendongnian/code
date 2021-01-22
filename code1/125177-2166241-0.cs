    using System;
    using System.Reflection;
    using System.Reflection.Emit;
    // the type we want to iterate efficiently without hard code
    class Foo
    {
        public int X, Y;
    }
    // what we want to do with each item of data
    class DemoPusher : IPusher<int>
    {
        public void Push(int value)
        {
            Console.WriteLine(value);
        }
    }
    // interface for the above implementation
    interface IPusher<T>
    {
        void Push(T value);
    }
    static class Program
    {
        // see it working
        static void Main()
        {
            Foo foo = new Foo { X = 1, Y = 2 };
            var target = new DemoPusher();
            var pushMethod = CreatePusher<int>(typeof(Foo));
            pushMethod(foo, target);       
        }
        // here be dragons
        static Action<object, IPusher<T>> CreatePusher<T>(Type source)
        {
            DynamicMethod method = new DynamicMethod("pusher",
                typeof(void), new[] { typeof(object), typeof(IPusher<T>) }, source);
            var il = method.GetILGenerator();
            var loc = il.DeclareLocal(source);
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Castclass, source);
            il.Emit(OpCodes.Stloc, loc);
            MethodInfo push = typeof(IPusher<T>).GetMethod("Push");
            foreach (var field in source.GetFields(BindingFlags.Instance
                | BindingFlags.Public | BindingFlags.NonPublic))
            {
                if (field.FieldType != typeof(T)) continue;
                il.Emit(OpCodes.Ldarg_1);
                il.Emit(OpCodes.Ldloc, loc);
                il.Emit(OpCodes.Ldfld, field);
                il.EmitCall(OpCodes.Callvirt, push, null);
            }
            il.Emit(OpCodes.Ret);
            return (Action<object, IPusher<T>>)
                method.CreateDelegate(typeof(Action<object, IPusher<T>>));
        }
        
    }
