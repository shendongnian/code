    using System.IO;
    String path= Path.GetDirectoryName(
     System.Reflection.Assembly.GetExecutingAssembly().CodeBase);
     DirectoryInfo dir = new DirectoryInfo(path);
     FileInfo[] fls = di.GetFiles("*.dll");
     foreach(FileInfo fi in fls )
        //do something
      
