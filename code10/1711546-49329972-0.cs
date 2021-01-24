    string xml = @"<InstanceData xmlns:xsi=""http://www.w3.org/2001/XMLSchema-
    instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
                                <letter>
                                <variableBlocks>
                                    <VariableBlockBase xsi:type=""ClientVariableBlock"">
                                        <FirstName></FirstName>
                                        <LastName></LastName>
                                        <Address></Address>
                                    </VariableBlockBase>
                                    <VariableBlockBase xsi:type=""PaymentVariableBlock"">
                                        <LastPaymentDate></LastPaymentDate>
                                        <LastPaymentAmount></LastPaymentAmount>
                                        <Address></Address> <!-- repeated (Address appear in the VariableBlockBase above) so this xml should be invalid -->
                                    </VariableBlockBase>
                              </variableBlocks>
                            </letter>
                        </InstanceData>";
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            XmlNodeList allElements = doc.SelectNodes("//VariableBlockBase/*");
            foreach(XmlElement childNode in doc.SelectNodes("InstanceData/letter/variableBlocks/*"))
            {
                foreach ( XmlElement grandChildNode in childNode.ChildNodes )
                {
                    try
                    {
                        allElements.Cast<XmlElement>().SingleOrDefault(x => x.Name == grandChildNode.Name);
                    }
                    catch ( InvalidOperationException )
                    {
                        throw new Exception("The tag <" + grandChildNode.Name + "> has been found more than once");
                    }
                    catch
                    {
                        throw;
                    }
                }
            }
