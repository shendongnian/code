    public static bool ChangeConnectionString(string Name, string value, string providerName, string AppName)
        {
            bool retVal = false;
            try
            {
                string FILE_NAME = string.Concat(Application.StartupPath, "\\", AppName.Trim(), ".exe.Config"); //the application configuration file name
                XmlTextReader reader = new XmlTextReader(FILE_NAME);
                XmlDocument doc = new XmlDocument();
                doc.Load(reader);
                reader.Close();
                string nodeRoute = string.Concat("connectionStrings/add");
                XmlNode cnnStr = null;
                XmlElement root = doc.DocumentElement;
                XmlNodeList Settings = root.SelectNodes(nodeRoute);
                for (int i = 0; i < Settings.Count; i++)
                {
                    cnnStr = Settings[i];
                    if (cnnStr.Attributes["name"].Value.Equals(Name))
                        break;
                    cnnStr = null;
                }
                cnnStr.Attributes["connectionString"].Value = value;
                cnnStr.Attributes["providerName"].Value = providerName;
                doc.Save(FILE_NAME);
                retVal = true;
            }
            catch (Exception ex)
            {
                retVal = false;
                //Handle the Exception as you like
            }
            return retVal;
        }
