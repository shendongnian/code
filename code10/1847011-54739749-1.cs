    [assembly: Dependency(typeof(UploadFileImplementation))]
    namespace xxx.Droid
    {
      public class UploadFileImplementation : IUploadFile
      {
        public UploadFileImplementation () { }
        public UploadFile(string filePath,string fileName)
        {
            // upload file here
          
        }
      }
    }
