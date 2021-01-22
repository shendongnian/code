    AssemblyName aName = new AssemblyName("dynamic");
    AssemblyBuilder ab = AppDomain.CurrentDomain.DefineDynamicAssembly(aName, AssemblyBuilderAccess.RunAndSave);
    ModuleBuilder mb = ab.DefineDynamicModule("dynamic.dll");
    TypeBuilder tb = mb.DefineType("Pizza");
    //Define your type here based on the info in your xml
    Type theType = tb.CreateType();
    
    //instanciate your object
    ConstructorInfo ctor = theType.GetConstructor(Type.EmptyTypes);
    object inst = ctor.Invoke(new object[]{});
    PropertyInfo[] pList = theType.GetProperties(BindingFlags.DeclaredOnly);
    //iterate through all the properties of the instance 'inst' of your new Type
    foreach(PropertyInfo pi in pList)
        Console.WriteLine(pi.GetValue(inst, null));
 
