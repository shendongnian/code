    compilerParams.ReferencedAssemblies.Add(typeof(IPlugin).Assembly.Location);
    compilerParams.GenerateExecutable = false; // generate the DLL
    
    // if you want to debug, this is needed...
    compilerParams.GenerateInMemory = false;
    compilerParams.TempFiles = new TempFileCollection(Environment.
          GetEnvironmentVariable("TEMP"), true);
