            public static string GetTempFile()
            {
                // get temporary path
                var tempPath = Path.GetTempPath();
                
                // get temporary filename
                string tempFileName = Path.GetRandomFileName();
    
                //combine 
                return Path.Combine(tempPath, tempFileName);
            }
