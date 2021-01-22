        private static bool HasWriteAccessToFile(string filePath)
        {
            try
            {
                // Attempt to get a list of security permissions from the file. 
                // This will raise an exception if the path is read only or do not have access to view the permissions. 
                File.GetAccessControl(filePath);
                return true;
            }
            catch (UnauthorizedAccessException)
            {
                return false;
            }
        }
