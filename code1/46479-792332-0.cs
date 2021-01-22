    // Get the current application domain for the current thread
    AppDomain currentDomain = AppDomain.CurrentDomain;
    // Create a dynamic assembly in the current application domain,
    // and allow it to be executed and saved to disk.
    AssemblyName name = new AssemblyName("MyEnums");
    AssemblyBuilder assemblyBuilder = currentDomain.DefineDynamicAssembly(name,
                                          AssemblyBuilderAccess.RunAndSave);
    // Define a dynamic module in "MyEnums" assembly.
    // For a single-module assembly, the module has the same name as the assembly.
    ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule(name.Name,
                                      name.Name + ".dll");
    // Define a public enumeration with the name "MyEnum" and an underlying type of Integer.
    EnumBuilder myEnum = moduleBuilder.DefineEnum("EnumeratedTypes.MyEnum",
                             TypeAttributes.Public, typeof(int));
    // Get data from database
    MyDataAdapter someAdapter = new MyDataAdapter();
    MyDataSet.MyDataTable myData = myDataAdapter.GetMyData();
    foreach (MyDataSet.MyDataRow row in myData.Rows)
    {
        myEnum.DefineLiteral(row.Name, row.Key);
    }
    // Create the enum
    myEnum.CreateType();
    // Finally, save the assembly
    assemblyBuilder.Save(name.Name + ".dll");
