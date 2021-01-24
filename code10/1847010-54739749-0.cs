    [assembly: Dependency(typeof(UploadFileImplementation))]
    namespace xxx.iOS
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
