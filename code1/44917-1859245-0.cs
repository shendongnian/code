    using System.Reflection;
    using System.IO;
    
    FileVersionInfo fv = System.Diagnostics.FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location);
    
    Console.WriteLine("AssemblyVersion : {0}", Assembly.GetExecutingAssembly().GetName().Version.ToString());
    
    Console.WriteLine ("AssemblyFileVersion : {0}" , fv.FileVersion.ToString ());
