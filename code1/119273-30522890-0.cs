     public class FileHttpResponseMessage : HttpResponseMessage
        {
            private readonly string filePath;
    
            public FileHttpResponseMessage(string filePath)
            {
                this.filePath = filePath;
            }
    
            protected override void Dispose(bool disposing)
            {
                base.Dispose(disposing);
                Content.Dispose();
                File.Delete(filePath);
            }
        }
