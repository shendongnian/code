    I am using this for my personal project to get all images
      
    using Directory = Pri.LongPath.Directory;
    // To handle long folder names Pri external library is used.
    // Source https://github.com/peteraritchie/LongPath
    using DirectoryInfo = Pri.LongPath.DirectoryInfo;
    using File = Pri.LongPath.File;
    using FileInfo = Pri.LongPath.FileInfo;
    using Path = Pri.LongPath.Path;
    
    
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
    
    
       static void Main(string[] args)
            {
                var dr = new DirectoryInfo("C:\\FolderPath");
                string ImagesExtensions = "jpg,jpeg,jpe,jfif,png,gif,bmp,dib,tif,tiff";
                string[] imageValues = ImagesExtensions.Split(',');
    
                foreach (var type in imageValues)
                {
                    if (!string.IsNullOrEmpty(type.Trim()))
                    {
                        DirectoryTree(dr, "*." + type.Trim());
                       // Console output
                      Console.WriteLine(DirectoryTree(dr, "*." + type.Trim()));
                    }
    
                }
            }
