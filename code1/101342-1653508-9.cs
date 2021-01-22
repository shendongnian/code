        public static FileUploadResultDTO GetFilesFromRequest(HttpContextWrapper contextWrapper)
        {
            FileUploadResultDTO result = new FileUploadResultDTO();
            result.Files = new List<File>();
            foreach (string file in contextWrapper.Request.Files)
            {
                HttpPostedFileBase hpf = contextWrapper.Request.Files[file] as HttpPostedFileBase;
                if (hpf.ContentLength > 0)
                {
                    File tempFile = new File()
                    {
                        UploadFileName = Regex.Match(hpf.FileName, @"(/|\\)?(?<fileName>[^(/|\\)]+)$").Groups["fileName"].ToString(),   // to trim off whole path from browsers like IE
                        MimeType = hpf.ContentType,
                        Data = FileService.ReadFully(hpf.InputStream, 0),
                        Length = (int)hpf.InputStream.Length
                    };
                    result.Files.Add(tempFile);
                    result.TotalBytes += tempFile.Length;
                }
            }
            return result;
        }
