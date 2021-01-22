    using System;
    using System.Reflection;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            public Int32 Add(Int32 a, Int32 b) { return a + b; }
            static void Main(string[] args)
            {
                Program obj = new Program();
    
                MethodInfo m = obj.GetType().GetMethod("Add");
                Int32 result = (Int32)m.Invoke(obj, new Object[] { 1, 2 });
            }
        }
    }
