    using System;
    using System.Reflection;
    using System.Reflection.Emit;
    var myAssembly = AppDomain.CurrentDomain.DefineDynamicAssembly(
			new AssemblyName("Test"), AssemblyBuilderAccess.RunAndSave);
    var myModule = myAssembly.DefineDynamicModule("Test.dll");
    var myType = myModule.DefineType("ProxyType", TypeAttributes.Public | TypeAttributes.Class,
                            typeof(TypeToSeverelyModifyInAnUglyWayButItsNecessary));
    var myMethod = myType.DefineMethod("MethodNameToOverride", 
                            MethodAttributes.HideBySig | MethodAttributes.Public,
                            typeof(void),Type.EmptyTypes);
    var myIlGenerator = myMethod.GetILGenerator();
	myIlGenerator.Emit(OpCodes.Ret);
    var type = myType.CreateType();
