    using System;
    using System.IO;
    
    public static class GetFilesTest {
      public static void Main() {
        int counter = 0;
        DirectoryInfo dir = new DirectoryInfo(@"C:\Test");
        foreach (FileSystemInfo fsi in dir.GetFileSystemInfos("*.txt")) {
          Console.WriteLine("########### FileSystemInfo {0} ###########", ++counter);
          Console.WriteLine("fsi: {0}", fsi);
          Console.WriteLine("Exists: {0}", fsi.Exists);
          Console.WriteLine("FullName: {0}", fsi.FullName);
          Console.WriteLine("Name: {0}", fsi.Name);
          Console.WriteLine("Extension: {0}", fsi.Extension);
          Console.WriteLine("Attributes: {0}", fsi.Attributes);
        }
    
        counter = 0;
        string[] files = {@"C:\Test\test.txt", @"C:\Test\test2.txt"};
        foreach(string file in files) {
          FileSystemInfo fi = new FileInfo(file);
          Console.WriteLine("########### FileInfo {0} ###########", ++counter);
          Console.WriteLine("fi: {0}", fi);
          Console.WriteLine("Exists: {0}", fi.Exists);
          Console.WriteLine("FullName: {0}", fi.FullName);
          Console.WriteLine("Name: {0}", fi.Name);
          Console.WriteLine("Extension: {0}", fi.Extension);
          Console.WriteLine("Attributes: {0}", fi.Attributes);
          Console.WriteLine("Contents: {0}", File.ReadAllText(fi.FullName));
        }
      }
    }
