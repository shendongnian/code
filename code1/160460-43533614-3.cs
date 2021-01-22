    // To handle long folder names Pri external library is used.
    // Source https://github.com/peteraritchie/LongPath    
    using Directory = Pri.LongPath.Directory;
    using DirectoryInfo = Pri.LongPath.DirectoryInfo;
    using File = Pri.LongPath.File;
    using FileInfo = Pri.LongPath.FileInfo;
    using Path = Pri.LongPath.Path;
    
    // Directory and sub directory search function
     public void DirectoryTree(DirectoryInfo dr, string searchname)
            {
                FileInfo[] files = null;
                var allFiles = new List<FileInfo>();
                try
                {
                    files = dr.GetFiles(searchname);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
    
                if (files != null)
                {
                    try
                    {
                        foreach (FileInfo fi in files)
                        {
                            allFiles.Add(fi);
    
                            string fileName = fi.DirectoryName + "\\" + fi.Name;
                            string orgFile = fileName;
                        }
                        var subDirs = dr.GetDirectories();
    
                        foreach (DirectoryInfo di in subDirs)
                        {
                            DirectoryTree(di, searchname);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
    
                }
            }
    
       public List<String> GetImagesPath(String folderName)
        {
           var dr = new DirectoryInfo(folderName);
           string ImagesExtensions = "jpg,jpeg,jpe,jfif,png,gif,bmp,dib,tif,tiff";
           string[] imageValues = ImagesExtensions.Split(',');
           List<String> imagesList = new List<String>();
    
                    foreach (var type in imageValues)
                    {
                        if (!string.IsNullOrEmpty(type.Trim()))
                        {
                            DirectoryTree(dr, "*." + type.Trim());
                            // output to list 
                           imagesList.Add = DirectoryTree(dr, "*." + type.Trim());
                        }
                  
                    }
             return imagesList;
      }
