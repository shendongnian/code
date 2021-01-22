public static bool FileComplete(string filePath)
        {
            try
            {
                File.Open(filePath, FileMode.Open, FileAccess.ReadWrite, FileShare.None);
                return true;
            }
            catch { return false; }
        }
