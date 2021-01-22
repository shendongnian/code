            static void delete(DirectoryInfo di)
            {
                foreach (FileInfo fi in di.GetFiles())
                {
                    try
                    {
                        fi.Delete();
                    }
                    catch (Exception)
                    {
                        
                    }
                }
    
                foreach (DirectoryInfo di2 in di.GetDirectories())
                {
                    delete(di2);
                }
                try
                {
                    di.Delete();
                }
                catch (Exception)
                {
                }
                
            }
