    Assembly assembly = null;
    foreach(Assembly loadedAssembly in AppDomain.CurrentDomain.GetAssemblies())
    	if (loadedAssembly.FullName == "foobar, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null")
    		assembly = loadedAssembly;
    
    if(assembly == null)
    {
    	byte[] studybin = System.IO.File.ReadAllBytes(@"C:\pathToAssembly\foobar.dll");
    	assembly = Assembly.Load(studybin);                
    }
