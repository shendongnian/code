    public class MyFileInfo : IFileInfo
    {
      public string MyString { get; set; }
    }
    
    Import<MyFileInfo>(files,
                       (mfi) => Console.WriteLine("Import {0}", mfi.MyString));
