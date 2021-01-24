    var parameters = new CompilerParameters();
    parameters.ReferencedAssemblies.AddRange(references);
    parameters.EmbeddedResources.AddRange(resources);
    parameters.GenerateExecutable = true;
    parameters.GenerateInMemory = false;
    parameters.IncludeDebugInformation = true;
    parameters.CompilerOptions = "/optimize";
    parameters.MainClass = entryPoint;
