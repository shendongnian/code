    var DLL = Assembly.LoadFile(@"C:\Microsoft.Exchange.WebServices.dll");
    var isEqualsTo = DLL.GetType("Microsoft.Exchange.WebServices.Data.SearchFilter+IsEqualTo");
    var param1 = DLL.GetType("Microsoft.Exchange.WebServices.Data.FolderSchema").GetField("DisplayName").GetValue(null);
    var param2 = "C:\\";
    var instance1 = Activator.CreateInstance(isEqualsTo, new[] { param1, param2 });
    // or...
    var typeParam1 = DLL.GetType("Microsoft.Exchange.WebServices.Data.PropertyDefinitionBase");
    var typeParam2 = typeof(object);
    var ctor = isEqualsTo.GetConstructor(new[] { typeParam1, typeParam2 });
    var instance2 = ctor.Invoke(new[] { param1, param2 });
