    public class Program
    {
        [STAThread()]
        public static void Main(string[] args)
        {
            Strange bar = null;
            var hello = new DynamicMethod("ThisIsNull",
                typeof(void), new[] { typeof(Strange) },
             typeof(Strange).Module);
            ILGenerator il = hello.GetILGenerator(256);
            il.Emit(OpCodes.Ldarg_0);
            var foo = typeof(Strange).GetMethod("Foo");
            il.Emit(OpCodes.Call, foo);
            il.Emit(OpCodes.Ret);
            var print = (HelloDelegate)hello.CreateDelegate(typeof(HelloDelegate));
            print(bar);
            Console.ReadLine();
        }
    }
