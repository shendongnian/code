    class P
        {
            public static void Main()
            {
                object[] args = { "1", new Exception()};
                MethodInfo mi = typeof(P).GetMethod("Method");
                try
                {
                    mi.Invoke(null, args);
                }
                catch
                {
                }
                Console.WriteLine(args[0].ToString());
                Console.WriteLine(args[1].ToString());
            }
            public static void Method(ref string arg, ref Exception ex)
            {
                try
                {
                    arg = "out value";
                    throw new Exception();
                }
                catch (Exception exc)
                {
                    ex = exc;
                }
            }
    }
