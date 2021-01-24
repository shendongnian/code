     /// <summary>
                /// Get values of the connection string in the following order :
                /// Server , Database,
                /// If the length of the list is 3 then the 3rd object is True (Integrated Security)
                /// If it is 4 then the 3rd object is the 3rd object is the username and the 4th is the password.
                /// 
                /// </summary>
                /// <returns></returns>
                public static List<string> GetCurrentConnectionString()
                {
                    try
                    {
                        List<string> lstConnStrData = new List<string>();
                        string[] aryConnStrData = new string[1];
                        // OPen the Config file as XML document and loop over it.
                        XmlDocument XmlDoc = new XmlDocument();
                        //Loading the Config file
                        XmlDoc.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
                        foreach (XmlElement xElement in XmlDoc.DocumentElement)
                        {
                            if (xElement.Name == "connectionStrings")
                            {
                                //setting the coonection string
                                aryConnStrData = xElement.ChildNodes[1].Attributes[1].Value.Split(';');
                                break;
                            }
        
                        }
        
                        // Now loop over the array that holds the conn str data and split each item on "=",
                        // and add the second splitted item to the list, so at the end the list will contains 
                        // the values of the connection string.
        
                        for (int i = 0; i <= aryConnStrData.Length - 2; i++)
                        {
                            lstConnStrData.Add(aryConnStrData[i].Split('=')[1]);
                        }
                        return lstConnStrData;
                    }
                    catch (Exception)
                    {
        
                        throw;
                    }
                }
