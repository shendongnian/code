                     public bool IsInUse(string path)
                     { 
                        bool IsFree = true;
                        try
                        {
                            //Just opening the file as open/create
                            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                            {
                            //we can check by using
                             fs.CanRead // or
                             fs.CanWrite
                            }
                           
                        }
                        catch (IOException ex)
                        {
                            IsFree = false;
                        }
                        return IsFree;
                     } 
    
                         string path = "D:\\test.doc";
                         bool IsFileFree = IsInUse(path);
   
