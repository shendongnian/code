     foreach (string file in System.IO.Directory.GetFiles(path))
                {
                    System.IO.File.Delete(file);
                }
    
                foreach (string subDirectory in System.IO.Directory.GetDirectories(path))
                {
                    System.IO.Directory.Delete(subDirectory,true); 
                    
                } 
