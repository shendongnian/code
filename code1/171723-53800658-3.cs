      public static class ImageRename
        {
            public static void ApplyChanges(string fileUrl,
                                            string temporaryImageName, 
                                            string permanentImageName)
            {               
                    var currentFileName = Path.Combine(fileUrl, 
                                                       temporaryImageName);
    
                    if (!File.Exists(currentFileName))
                        throw new FileNotFoundException();
    
                    var extention = Path.GetExtension(temporaryImageName);
                    var newFileName = Path.Combine(fileUrl, 
                                                $"{permanentImageName}
                                                  {extention}");
    
                    if (File.Exists(newFileName))
                        File.Delete(newFileName);
    
                    File.Move(currentFileName, newFileName);               
            }
        }
