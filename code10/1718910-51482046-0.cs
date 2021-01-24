     [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file != null)
            {
                using (var stream = new MemoryStream())
                {
                    try
                    {
                        // assume a single file POST
                        await file.CopyToAsync(stream);
                        stream.Seek(0, SeekOrigin.Begin);
                        // now send up to Azure
                        var filename = file.FileName;
                        var storageAccount = CloudStorageAccount.Parse(<YOUR CREDS HERE>);
                        var client = storageAccount.CreateCloudFileClient();
                        var shareref = client.GetShareReference("YOUR FILES SHARE");
                        var rootdir = shareref.GetRootDirectoryReference();
                        var fileref = rootdir.GetFileReference(filename);
                        await fileref.DeleteIfExistsAsync();
                        await fileref.UploadFromStreamAsync(stream);
                        return Ok(new { fileuploaded = true });
                    }
                    catch (Exception ex)
                    {
                        return BadRequest(ex);
                    }
                }
            }
            else
            {
                return BadRequest(new { error = "there was no uploaded file" });
            }
        }
