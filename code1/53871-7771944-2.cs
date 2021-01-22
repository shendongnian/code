    // to get the location the assembly is executing from
    //(not necessarily where the it normally resides on disk)
    // in the case of the using shadow copies, for instance in NUnit tests, 
    // this will be in a temp directory.
    string path = System.Reflection.Assembly.GetExecutingAssembly().Location;
    
    //To get the location the assembly normally resides on disk or the install directory
    string path = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
    
    //once you have the path you get the directory with:
    var directory = System.IO.Path.GetDirectoryName(path);
