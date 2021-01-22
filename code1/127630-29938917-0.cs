             //Store the number of days after which you want to delete the logs.
             int Days = 30;
              // Storing the path of the directory where the logs are stored.
               String DirPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase).Substring(6) + "\\Log(s)\\";
              
              //Fetching all the folders.
                String[] objSubDirectory = Directory.GetDirectories(DirPath);
                //For each folder fetching all the files and matching with date given 
                foreach (String subdir in objSubDirectory)     
                {
                    //Getting the path of the folder                 
                    String strpath = Path.GetFullPath(subdir);
                    //Fetching all the files from the folder.
                    String[] strFiles = Directory.GetFiles(strpath);
                    foreach (string files in strFiles)
                    {
                        //For each file checking the creation date with the current date.
                        FileInfo objFile = new FileInfo(files);
                        if (objFile.CreationTime <= DateTime.Now.AddDays(-Days))
                        {
                            //Delete the file.
                            objFile.Delete();
                        }
                    }
                    //If folder contains no file then delete the folder also.
                    if (Directory.GetFiles(strpath).Length == 0)
                    {
                        DirectoryInfo objSubDir = new DirectoryInfo(subdir);
                        //Delete the folder.
                        objSubDir.Delete();
                    }
                }
            
           
