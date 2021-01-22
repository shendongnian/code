    AppDomain newDomain = AppDomain.CreateDomain("newDomain", e, setup);
    string fullName = Assembly.GetExecutingAssembly().FullName;
    Type loaderType = typeof(AssemblyLoader);
    FileStream fs = new FileStream(@"library.dll", FileMode.Open);
    byte[] buffer = new byte[(int)fs.Length];
    fs.Read(buffer, 0, buffer.Length);
    fs.Close();
    
    Assembly domainLoaded = newDomain.Load(buffer);
    object loaded = Activator.CreateInstance(domainLoaded.GetTypes()[1]);
    AppDomain.Unload(newDomain);
    GC.Collect();
    GC.WaitForPendingFinalizers();
