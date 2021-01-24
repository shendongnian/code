            private ActionResult GetFile(string path, string fileName)
            {
                var memory = new MemoryStream();
                using (var stream = new FileStream(path + fileName, FileMode.Open))
                {
                    stream.CopyTo(memory);
                }
                memory.Position = 0;
                var file = File(memory, GetContentType(path + fileName), Path.GetFileName(path + fileName));
                file.FileDownloadName = fileName;
                return file;
            }
    
            private string GetContentType(string path)
            {
                var types = GetMimeTypes();
                var ext = Path.GetExtension(path).ToLowerInvariant();
                return types[ext];
            }
            //find out what .csv is these won't work for you
            private Dictionary<string, string> GetMimeTypes()
            {
                return new Dictionary<string, string>
                {
                    //{".pptx", "application/vnd.openxmlformats-officedocument.presentationml.presentation" }
                    //{".docx", "application/vnd.ms-word"}
                    //{".pdf", "application/pdf"}
                };
            }
