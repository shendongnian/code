    [TestMethod]
    public void CanExecute_On_LoadedClass1()
    {
        // Load Assembly and Types
        var assm = Assembly.LoadFile(@"C:\Lib\ClassLibrary1.dll");
        var types = assm.GetExportedTypes();
    
        // Get object type informaiton
        var class1 = types.FirstOrDefault(t => t.Name == "Class1");
        Assert.IsNotNull(class1);
    
        var wasWorkDone = class1.GetProperty("WasWorkDone");
        Assert.IsNotNull(wasWorkDone);
        
        var doWork = class1.GetMethod("DoWork");
        Assert.IsNotNull(doWork);
    
        // Create Object
        var class1Instance = Activator.CreateInstance(class1.UnderlyingSystemType);
    
        // Do Work
        bool wasDoneBeforeInvoking = 
              (bool)wasWorkDone.GetValue(class1Instance, null);
        doWork.Invoke(class1Instance, null);
        bool wasDoneAfterInvoking = 
              (bool)wasWorkDone.GetValue(class1Instance, null);
        // Assert
        Assert.IsFalse(wasDoneBeforeInvoking);
        Assert.IsTrue(wasDoneAfterInvoking);
    }
