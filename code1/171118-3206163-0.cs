    //in your imports/using section
    using System.IO
    using System.Reflection
    using System.Diagnostics;
    
    //in your code to execute
    Process.start(Path.GetDirectoryName(Aseembly.GetExecutingAssembly().GetName().CodeBase) + "\\program.exe")
