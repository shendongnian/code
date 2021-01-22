    // Get the version of the current application.
    Assembly assem = Assembly.GetExecutingAssembly();
    AssemblyName assemName = assem.GetName();
    Version ver = assemName.Version;
    Console.WriteLine("{0}, Version {1}", assemName.Name, ver.ToString());
