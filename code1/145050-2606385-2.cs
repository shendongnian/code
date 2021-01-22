         var result = CompileAssemblyFromSource(
    settings,
    // only one string of code
    new[] { String.Format("using {0};", name) );               
         return result.Errors
             .OfType<CompilerError>()
             .Count(e => e.ErrorText == "CS0234") > 0:
           // you can search for specific error
           // or check any error existence using result.Errors.HasErrors
  }
    }
