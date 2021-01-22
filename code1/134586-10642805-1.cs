            private static void UpdateMetaData(string strListName, string rowLimit, string strDocTitle, string FieldName, string NewValue)
            {
                Lists_WinAuth.Lists li = new Lists_WinAuth.Lists();
                li.Credentials = new NetworkCredential("yourUserID", "YourPwd", "YourDomain");
                XmlDocument xmlDoc = new System.Xml.XmlDocument();
                /////////get id            
                XmlNode ndQuery = xmlDoc.CreateNode(XmlNodeType.Element, "Query", "");
                XmlNode ndViewFields = xmlDoc.CreateNode(XmlNodeType.Element, "ViewFields", "");
                XmlNode ndQueryOptions = xmlDoc.CreateNode(XmlNodeType.Element, "QueryOptions", "");
                ndQueryOptions.InnerXml = "<IncludeMandatoryColumns>FALSE</IncludeMandatoryColumns>" +
                                          "<DateInUtc>TRUE</DateInUtc>";
                ndViewFields.InnerXml = "<FieldRef Name='ID' /> ";
                ndQuery.InnerXml = "<Where>" +
                                    "<Eq>" +
                                    "<FieldRef Name='FileLeafRef' />" +
                                    "<Value Type='Text'>" + strDocTitle + "</Value>" +
                                    "</Eq>" +
                                    "</Where>";
                XmlNode ndListItems = li.GetListItems(strListName, "", ndQuery, ndViewFields, rowLimit, ndQueryOptions, null);
                string strDocID = ndListItems.ChildNodes[1].ChildNodes[1].Attributes[0].Value.ToString();
                //////////update
                string strBatch = "<Method ID='1' Cmd='Update'>" +
                                  "<Field Name='ID'>" + strDocID + "</Field>" +
                                  "<Field Name='" + FieldName + "'>" + NewValue + "</Field></Method>";
                System.Xml.XmlElement elBatch = xmlDoc.CreateElement("Batch");
                elBatch.SetAttribute("OnError", "Continue");
                elBatch.InnerXml = strBatch;
                try
                {
                    XmlNode ndReturn = li.UpdateListItems("Shared Documents", elBatch);
                }
                catch (Exception ex)
                {
                    throw;
                }
                return;
            }
