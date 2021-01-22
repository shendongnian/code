    using ClassLibrary1; // this is another project that contains IMyInterface
    
    namespace ConsoleApplication1
    {
        public class MyBaseClass
        {
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                MyReflectionTest(typeof(ClassLibrary1.IMyInterface));
            }
    
            private static void MyReflectionTest(Type interfaceType)
            {
    
                AssemblyName aName = new AssemblyName("DynamicAssemblyExample");
                AssemblyBuilder ab = AppDomain.CurrentDomain.DefineDynamicAssembly(aName, AssemblyBuilderAccess.RunAndSave);
    
                ModuleBuilder mb = ab.DefineDynamicModule(aName.Name, aName.Name + ".dll");
    
                TypeBuilder tb = mb.DefineType("MyDynamicType", TypeAttributes.Public, typeof(MyBaseClass), new Type[] { interfaceType });
    
                MethodBuilder mbIM = tb.DefineMethod("IMyInterface.MyTestMethod", MethodAttributes.Private | MethodAttributes.HideBySig | MethodAttributes.NewSlot | MethodAttributes.Virtual | MethodAttributes.Final, null, Type.EmptyTypes);
                ILGenerator il = mbIM.GetILGenerator();
                il.Emit(OpCodes.Ret);
    
                tb.DefineMethodOverride(mbIM, interfaceType.GetMethod("MyTestMethod"));
    
                var myType = tb.CreateType();
    
                Debug.Assert(interfaceType.IsAssignableFrom(myType) == true);
            } 
        }
    }
