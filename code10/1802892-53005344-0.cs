    private static async Task<bool> GenerateZipFile(FileSystemInfo file1, string zipFilePath)
    {
        try
        {
    		string newZipFilePath = $"{zipFilePath}\\test_{DateTime.UtcNow:yyyyMMddHHmmssfff}.Zip"
    		if (!System.IO.File.Exists(newZipFilePath))
    		{
    			using (var zip = ZipFile.Open(newZipFilePath, ZipArchiveMode.Create))
    			{
    				if(System.IO.File.Exists(file1.FullName))
    				{
    					zip.CreateEntryFromFile(file1.FullName, file1.Name, CompressionLevel.Optimal);
    				}
    			}
    		}
        }
        catch (Exception ex)
        {
            Console.Write(ex);
        }
    }
