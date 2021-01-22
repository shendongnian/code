        /// <summary>
        /// 
        /// </summary>
        /// <param name="p_AppConfigFile"></param>
        /// <returns></returns>
        private string DecryptConfigData(string p_AppConfigFile)
        {
            string decryptedData = null;
            TMS.Pearl.SystemFramework.CryptographyManager.CryptographyManager cryptManager = new TMS.Pearl.SystemFramework.CryptographyManager.CryptographyManager();
            try
            {
                //Attempt to load the file.
                if (File.Exists(p_AppConfigFile))
                {
                    //Load the file's contents and decrypt them if they are encrypted.
                    string rawData = File.ReadAllText(p_AppConfigFile);
                    if (!string.IsNullOrEmpty(rawData))
                    {
                        if (!rawData.Contains("<?xml"))  //assuming that all unencrypted config files will start with an xml tag...
                        {
                            decryptedData = cryptManager.Decrypt(rawData);
                        }
                        else
                        {
                            decryptedData = rawData;
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return decryptedData;
        }
