          public static bool IsLocked(this FileInfo f)
        {
                try 
                {
                    string fpath = f.FullName;
                    FileStream fs = File.OpenWrite(fpath);
                    fs.Close();        
                    return false;
                }
                
                catch (Exception) { return true; }      
        }
