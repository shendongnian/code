    public static string[] CreateTestFolders(string testDirectory)
    {
        _testFolders = new string[] { @"TestFolder1", @"TestFolder2", @"TestFolder3", @"TestFolder4", @"TestFolder5" };
        for (int i = 0; i < _testFolders.Length - 1; i++)
        {
            try
            {
                _testFolders[i] = Directory.CreateDirectory(testDirectory + _testFolders[i]).FullName;
            }
            catch(Exception ex)
            {
                string exm = Environment.UserName + " " + ex.Message;
            }
        }
        return _testFolders;
    }
