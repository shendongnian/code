        public async Task WriteAsync(IEnumerable<LocalFile> files)
        {
  
            var folder = files.Select(x => x.Folder).FirstOrDefault() 
             ?? DateTime.Now.ToString("yyyy-MM-dd hh-mm-ss");
      
            using (var archiveStream = new MemoryStream())
            {
                using (var archive = new ZipArchive(archiveStream, ZipArchiveMode.Create, true))
                {
                    foreach (var file in files)
                    {
                        using (var entry = archive.CreateEntry(file.RelativePath).Open())
                        using (var local = (await file.OpenLocal()))
                        {
                            local.CopyTo(entry);
                        }
                    }
                }
                var bytes = archiveStream.ToArray();
                var encryptionClient = new EncryptionClient("ahmad.zeitoun@medxm1.com", "Password7");
                var encryption = new EncryptFiles(encryptionClient);
                using (var encryptedStream = new MemoryStream())
                {
                    using (var zipStream = new MemoryStream(bytes))
                    {
                        encryption.Gpg.Encrypt(zipStream, encryptedStream);
                    }
                    this.bytesArr = encryptedStream.ToArray();
                }
            }
            await this.Writer.WriteAsync(new[] { new LocalFile(folder + ".zip.gpg", () => new MemoryStream(this.bytesArr)) });
