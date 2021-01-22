    public string ProcessLocalAppConfig(string p_ConfigFilePath)
    {
        try
        {
            string fileName = Path.GetTempFileName();
            string unencryptedConfig = DecryptConfigData(p_ConfigFilePath);
            FileStream fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            StreamWriter streamWriter = new StreamWriter(fileStream);
            
            if (!string.IsNullOrEmpty(unencryptedConfig))
            {
                try
                {
                    streamWriter.BaseStream.Seek(0, SeekOrigin.End);
                    streamWriter.WriteLine(unencryptedConfig);
                }
                catch (IOException ex)
                {
                    Debug.Assert(false, ex.ToString());
                }
                finally
                {
                    streamWriter.Close();
                }
                return fileName;
            }
            return null;
        }
        catch (Exception)
        {
            throw;
        }
    }
    
