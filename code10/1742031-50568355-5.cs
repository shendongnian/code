        private bool check_dir(string outputDirectory)
        {
            try
            {
                if (Directory.Exists(outputDirectory))
                {
                    return true;
                }
                else
                {
                    Directory.CreateDirectory(outputDirectory);
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
