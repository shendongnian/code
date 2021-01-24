    private string Locate(string directory)
        {
            string result = string.Empty;
            string[] dirs = new string[0];
            try
            {
                dirs = Directory.GetDirectories(directory);
            }
            catch { /* Ignore */ }            
            foreach (string dir in dirs)
            {
                if (dir.EndsWith(SEARCH_PATTERN))
                {
                    result = dir;
                    break;
                }
                else
                {
                    result = this.Locate(dir);
                    if (result.EndsWith(SEARCH_PATTERN))
                    {
                        break;
                    }
                }                
            }           
            return result;
        }
