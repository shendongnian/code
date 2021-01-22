    try
            {
                byte[] imageData = null;
                if (flUpload != null)
                {
                    // This condition checks whether the user has uploaded a file or not
                    if ((flUpload.PostedFile != null) && (flUpload.PostedFile.ContentLength > 0))
                    {
                        Stream MyStream = flUpload.PostedFile.InputStream;
                        long iLength = MyStream.Length;
                        imageData = new byte[(int)MyStream.Length];
                        MyStream.Read(imageData, 0, (int)MyStream.Length);
                        MyStream.Close();
                        string filename = System.IO.Path.GetFileName(flUpload.PostedFile.FileName);                                                
                       SPPictureLibrary pic = (SPPictureLibrary)SPContext.Current.Web.Lists["Images"];//Images is the picture library name
                       SPFileCollection filecol = ((SPPictureLibrary)SPContext.Current.Web.Lists["Images"]).RootFolder.Files;//getting all the files which is in pictire library
                       filecol.Add(filename, imageData);//uploading the files to picturte library
                        
                    }
                }                
            }
            catch (Exception ex)
            {
                //handle it
            } 
