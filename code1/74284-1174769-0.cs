    if (FileUpload1.HasFile)
                {
                    if (System.IO.Path.GetExtension(FileUpload1.FileName).ToLower() == ".jpg")
                    {
                        fileOK = true;
                    }
                    if (fileOK)
                    {
                        try
                        {
                            FileUpload1.PostedFile.SaveAs(System.IO.Path.Combine(path,  newFileName + ".jpg"));
                        
