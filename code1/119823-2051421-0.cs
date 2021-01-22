    class Program
    {
        static void Main()
        {
            var t = typeof(Program);
            var dm = new DynamicMethod("MyCtor", t, new Type[0], t.Module);
            var ctor = t.GetConstructor(new Type[0]);
            ILGenerator ilgen = dm.GetILGenerator();
            ilgen.Emit(OpCodes.Newobj, ctor);
            ilgen.Emit(OpCodes.Ret);
            var del = (Func<Program>)dm.CreateDelegate(typeof(Func<Program>));
            var instance = del();
            Console.WriteLine(instance);
        }
    }
