    private static void MakeTempDatabaseCopy(string dbPath, string exePath)
    {
    	try
    	{
    		File.Copy(Path.Combine(dbPath, "Data", "Database.db"), Path.Combine(exePath, "Temp", "Database.db"), true);
    		FileInfo directoryInfo = new FileInfo(Path.Combine(exePath, "Temp", "Database.db"));
    		directoryInfo.Attributes = FileAttributes.Temporary;
    	}
    	catch (Exception ex)
    	{
    		MessageBox.Show(ex.Message, "Error Retrieving Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
    	}
    }
