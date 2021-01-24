    [assembly: Xamarin.Forms.Dependency (typeof (FileImplementation))]
    namespace File.iOS {
      public class FileImplementation : IFile
      {
          public FileImplementation() {}
    
          public void Copy(string fromFile, string toFile)
          {
                System.IO.File.Copy(fromFile, toFile);
          }
    
      }
    }
