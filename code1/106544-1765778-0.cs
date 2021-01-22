    Assembly a = BuildManager.GetCompiledAssembly("~/TestClass.cs");
    foreach (Type t in a.GetExportedTypes()) {
        object obj = Activator.CreateInstance(t)
        // Do something with obj...
    }
