    var trace = new StackTrace();
    Assembly entryAssembly = null;
    foreach (var frame in trace.GetFrames())
    {
       var assembly = frame.GetMethod().DeclaringType.Assembly;
       //check if the assembly is one you own & therefore could be your logical
       //"entry assembly". You could do this by checking the prefix of the
       //Assembly Name if you use some standardised naming convention, or perhaps
       //looking at the AssemblyCompanyAttribute, etc
       if ("assembly is one of mine")
       {
          entryAssembly = assembly;
       }
    }
