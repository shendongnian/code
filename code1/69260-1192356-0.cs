    //did the user upload any file?
                if (FileUpload1.HasFile)
                {
                    //Get the name of the file
                    string fileName = FileUpload1.FileName;
                //Does the file already exist?
                if (File.Exists(Server.MapPath(ConfigurationManager.AppSettings["fileUploadPath"].ToString() + fileName)))
                {
                    PanelError.Visible = true;
                    lblError.Text = "A file with the name <b>" + fileName + "</b> already exists on the server.";
                    return;
                }
                //Is the file too big to upload?
                int fileSize = FileUpload1.PostedFile.ContentLength;
                if (fileSize > (maxFileSize * 1024))
                {
                    PanelError.Visible = true;
                    lblError.Text = "Filesize of image is too large. Maximum file size permitted is " + maxFileSize + "KB";
                    return;
                }
                //check that the file is of the permitted file type
                string fileExtension = Path.GetExtension(fileName);
                fileExtension = fileExtension.ToLower();
                string[] acceptedFileTypes = new string[7];
                acceptedFileTypes[0] = ".pdf";
                acceptedFileTypes[1] = ".doc";
                acceptedFileTypes[2] = ".docx";
                acceptedFileTypes[3] = ".jpg";
                acceptedFileTypes[4] = ".jpeg";
                acceptedFileTypes[5] = ".gif";
                acceptedFileTypes[6] = ".png";
                bool acceptFile = false;
                //should we accept the file?
                for (int i = 0; i <= 6; i++)
                {
                    if (fileExtension == acceptedFileTypes[i])
                    {
                        //accept the file, yay!
                        acceptFile = true;
                    }
                }
                if (!acceptFile)
                {
                    PanelError.Visible = true;
                    lblError.Text = "The file you are trying to upload is not a permitted file type!";
                    return;
                }
                //upload the file onto the server
                FileUpload1.SaveAs(Server.MapPath(ConfigurationManager.AppSettings["fileUploadPath"].ToString() + fileName));
            }`
