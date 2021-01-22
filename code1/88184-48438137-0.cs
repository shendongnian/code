            public static bool HasWritePermission(string tempfilepath)
            {
                try
                {
                    System.IO.File.Create(tempfilepath + "temp.txt").Close();
                    System.IO.File.Delete(tempfilepath + "temp.txt");
                }
                catch (System.UnauthorizedAccessException ex)
                {
    
                    return false;
                }
    
                return true;
            }
