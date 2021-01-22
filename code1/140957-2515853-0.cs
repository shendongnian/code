    using System;
    using System.Reflection.Emit;
    static class Program
    {
        delegate void Evil<T>(out T value);
        static void Main()
        {
            MakeTheStackFilthy();
            Test();
        }
        static void Test()
        {
            int i;
            DynamicMethod mthd = new DynamicMethod("Evil", null, new Type[] { typeof(int).MakeByRefType()});
            mthd.GetILGenerator().Emit(OpCodes.Ret); // just return; no assignments
            Evil<int> evil = (Evil<int>)mthd.CreateDelegate(typeof(Evil<int>));
            evil(out i);
            Console.WriteLine(i);
        }
        static void MakeTheStackFilthy()
        {
            DateTime foo = new DateTime();
            Bar(ref foo);
            Console.WriteLine(foo);
        }
        static void Bar(ref DateTime foo)
        {
            foo = foo.AddDays(1);
        }
    }
