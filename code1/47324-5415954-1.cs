            try
            {
                //var constrnm=txtProviderName.Text.Trim();
                //var strbackup = BackUpName;
                //ConnectionStringSettings strNew = new ConnectionStringSettings(constrnm, txtNewPath.Text.Trim());
                //ConnectionStringSettings strNewBackUp = new ConnectionStringSettings( strbackup,txtBackupPath.Text.Trim());
                System.Xml.XmlDocument xDoc = new System.Xml.XmlDocument();
                path = "D:\\Pandurang\\Jitendra\\LocalFileTransfer\\LocalFileTransfer\\app.config";
                xDoc.Load(path);
                System.Xml.XmlElement element = xDoc.CreateElement("add");
                element.SetAttribute("name", txtProviderName.Text.Trim());
                element.SetAttribute("connectionString", txtNewPath.Text.Trim());
                System.Xml.XmlElement elementBackup = xDoc.CreateElement("add");
                elementBackup.SetAttribute("name", BackUpName);
                elementBackup.SetAttribute("connectionString", txtBackupPath.Text.Trim());
                System.Xml.XmlNode node= xDoc.ChildNodes[1].ChildNodes[0];
                node.AppendChild(element);
                node.AppendChild(elementBackup);
                xDoc.Save(path);
                //Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                //DumpToConsole(ConfigurationManager.ConnectionStrings, "Before AddAndSaveOneConnectionStringSettings.");
                //SaveConnectionString.AddAndSaveOneConnectionStringSettings(configuration, strNew);
                //SaveConnectionString.AddAndSaveOneConnectionStringSettings(configuration, strNewBackUp);
                //System.Configuration.ConfigurationManager.ConnectionStrings.Add(strNew);
                //System.Configuration.ConfigurationManager.ConnectionStrings.Add(strNewBackUp);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
