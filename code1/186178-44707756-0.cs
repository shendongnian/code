    public class ModelFile
    {
         .....
         public string Path{ get; set; }
         public ICollection<IFormFile> Upload { get; set; }
    }
    public async Task<IActionResult> Index([Bind("Upload,Path")] ModelFile modelfile)
    {
         ...
         msg = await storeFilesInServer(modelfile.Upload,modelfile.Path);
    }
    private async Task<Message> storeFilesInServer(ICollection<IFormFile> upload, string path)
            {
                Message msg = new Message();
                msg.Status = "OK";
                msg.Code = 100;
                msg.Text = "File uploaded successfully";
                msg.Error = "";
                string tempFileName = "";
                try
                {
                    foreach (var file in upload)
                    {
                        if (file.Length > 0)
                        {
                            string tempPath = path + @"\";
                            if (Request.Host.Value.Contains("localhost"))
                                tempPath = path + @"\"; 
                           
                            using (var fileStream = new FileStream(tempPath + file.FileName, FileMode.Create))
                            {
                                await file.CopyToAsync(fileStream);
                                tempFileName = file.FileName;
                            }
                        }
                        msg.Text = tempFileName;
                    }
                }
                catch (Exception ex)
                {
                    msg.Error = ex.Message;
                    msg.Status = "ERROR";
                    msg.Code = 301;
                    msg.Text = "There was an error storing the files, please contact support team";
                }
    
                return msg;
            }
