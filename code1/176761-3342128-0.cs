    public class MyBaseClass
    {
    }
    public interface IMyInterface
    {
        void MyTestMethod();
    }
    class Program
    {
        static void Main(string[] args)
        {
            AssemblyName aName = new AssemblyName("DynamicAssemblyExample");
            AssemblyBuilder ab = AppDomain.CurrentDomain.DefineDynamicAssembly(aName, AssemblyBuilderAccess.RunAndSave);
            ModuleBuilder mb = ab.DefineDynamicModule(aName.Name, aName.Name + ".dll");
            TypeBuilder tb = mb.DefineType("MyDynamicType", TypeAttributes.Public, typeof(MyBaseClass), new Type[] { typeof(IMyInterface) });
            MethodBuilder mbIM = tb.DefineMethod("IMyInterface.MyTestMethod", MethodAttributes.Private | MethodAttributes.HideBySig | MethodAttributes.NewSlot | MethodAttributes.Virtual | MethodAttributes.Final, null, Type.EmptyTypes);
            ILGenerator il = mbIM.GetILGenerator();
            il.Emit(OpCodes.Ret);
            tb.DefineMethodOverride(mbIM, typeof(IMyInterface).GetMethod("MyTestMethod"));
            var myType = tb.CreateType();
         
            Debug.Assert(typeof(IMyInterface).IsAssignableFrom(myType) == true);
        } 
    }
