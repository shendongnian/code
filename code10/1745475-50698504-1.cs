    public static string[] CreateTestFolders()
    {
        _testFolders = new string[] { @"TestFolder1", @"TestFolder2", @"TestFolder3", @"TestFolder4", @"TestFolder5" };
    
        for (int i = 0; i < _testFolders.Length - 1; i++)
        {
            try
            {
                // Also try with Application.StartupPath instead of Directory.GetCurrentDirectory()
                string currentPath = Path.Combine(Directory.GetCurrentDirectory(), _testFolders[i]);
                if (!Directory.Exists(currentPath)
                {
                    Directory.CreateDirectory(currentPath);
                }
                //at this point your folder should exist
            }
            catch(Exception ex)
            {
                string exm = Environment.UserName + " " + ex.Message;
            }
        }
        return _testFolders;
    }
