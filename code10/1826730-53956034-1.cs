     [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class FileUploadService : IFileUpload
    {
        public void Upload(byte[] bys)
        {
            string filename = Guid.NewGuid().ToString()+".pdf";
            File.WriteAllBytes(HttpContext.Current.Request.MapPath("/upload/") + filename, bys);
           
        }
    }
