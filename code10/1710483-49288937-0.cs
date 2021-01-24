    foreach (var project in solution.Projects)
    {
         var compilation = project.GetCompilationAsync().Result;
                
          // Look for a reference to the Class in the Assembly
          var classRef = compilation.GetTypeByMetadataName("RoslynTestTargetProject.Class1");
