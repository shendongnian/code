    public class ResultSetBinding
        {
            string ResultName;
            string DtsVariableName;
            string TaskName;
    
            public ResultSetBinding(string taskName, string resultName, string dtsVariableName)
            {
                TaskName = taskName;
                ResultName = resultName;
                DtsVariableName = dtsVariableName;
            }
    
            public void AddResultBinding(string filePath)
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(filePath);
    
                XmlElement root = doc.DocumentElement;
    
                var nsmgr = new XmlNamespaceManager(doc.NameTable);
                nsmgr.AddNamespace("DTS", "www.microsoft.com/SqlServer/Dts");
                nsmgr.AddNamespace("SQLTask", "www.microsoft.com/sqlserver/dts/tasks/sqltask");
    
                XmlNodeList executableNodes = root.SelectNodes("//DTS:Executable", nsmgr);
    
                foreach (XmlNode executableNode in executableNodes)
                {
                    if (IsExecuteSQLTask(executableNode, nsmgr))
                    {
                        if (IsSpecifiedTask(executableNode, nsmgr))
                        {
                            AddResultBindingToNode(doc, executableNode, nsmgr);
                        }
                    }
                }
                doc.PreserveWhitespace = true;
                doc.Save(filePath);
            }
    
            private bool IsExecuteSQLTask(XmlNode executableNode, XmlNamespaceManager nsmgr)
            {
                foreach (XmlAttribute executableAttribute in executableNode.Attributes)
                {
                    if (executableAttribute.Name == "DTS:ExecutableType")
                    {
                        return executableAttribute.Value.Contains("ExecuteSQLTask");
                    }
                }
                return false;
            }
    
            private bool IsSpecifiedTask(XmlNode executableNode, XmlNamespaceManager nsmgr)
            {
                foreach (XmlNode propertyNode in executableNode.ChildNodes)
                {
                    if (propertyNode.Name == "DTS:Property")
                    {
                        foreach (XmlAttribute propertyAttribute in propertyNode.Attributes)
                        {
                            if (propertyAttribute.Name == "DTS:Name" && propertyAttribute.Value == "ObjectName" && propertyNode.InnerText == TaskName)
                            {
                                return true;
                            }
                        }
                    }
                }
                return false;
            }
    
            private void AddResultBindingToNode(XmlDocument doc, XmlNode executableNode, XmlNamespaceManager nsmgr)
            {
                foreach (XmlNode objectNode in executableNode.ChildNodes)
                {
                    if (objectNode.Name == "DTS:ObjectData")
                    {
                        foreach (XmlNode sqlNode in objectNode.ChildNodes)
                        {
                            if (sqlNode.Name == "SQLTask:SqlTaskData")
                            {
                                XmlElement bindingElement = doc.CreateElement("SQLTask:ResultBinding", "www.microsoft.com/sqlserver/dts/tasks/sqltask");
    
                                bindingElement.SetAttribute("ResultName", "www.microsoft.com/sqlserver/dts/tasks/sqltask", ResultName);
                                bindingElement.SetAttribute("DtsVariableName", "www.microsoft.com/sqlserver/dts/tasks/sqltask", String.Format("User::{0}", DtsVariableName));
    
                                sqlNode.AppendChild(bindingElement);
                            }
                        }
                    }
                }
            }
        }
