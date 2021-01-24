    var asm = Assembly.UnsafeLoadFrom(fileName);
    string addInInterfaceName = typeof(IMyAddIn).FullName;
    foreach (Type type in asm.GetExportedTypes()) {
        Type interfaceType = type.GetInterface(addInInterfaceName);
        if (interfaceType != null &&
            (type.Attributes & TypeAttributes.Abstract) != TypeAttributes.Abstract)
        {
            var addIn = (IMyAddIn)Activator.CreateInstance(type);
            // Let's assume that each add-in has only one class implementing the interface
            return addIn.GetUrl(input);
        }
    }
