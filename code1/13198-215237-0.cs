    using System;
    using System.Linq;
    using System.Reflection;
    using System.Windows.Forms;
    
    public class Test 
    {
        static void Main()
        {
            Type clazz = typeof(Application).GetNestedType("ThreadContext", BindingFlags.NonPublic);
            Type iface = typeof(Form).Assembly.GetType("System.Windows.Forms.UnsafeNativeMethods+IMsoComponent");
            InterfaceMapping map = clazz.GetInterfaceMap(iface);
            MethodInfo method = map.TargetMethods.Where(m => m.Name.EndsWith(".FDoIdle")).Single();
            Console.WriteLine(method.Name);
        }
    }
