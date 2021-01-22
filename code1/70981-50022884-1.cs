    var fso = new Scripting.FileSystemObject();
    var folder = fso.GetFolder(@"C:\Windows");
    double sizeInBytes = folder.Size;
    // cleanup COM
    System.Runtime.InteropServices.Marshal.ReleaseComObject(folder);
    System.Runtime.InteropServices.Marshal.ReleaseComObject(fso);
