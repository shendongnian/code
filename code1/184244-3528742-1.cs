    var QueryResultSet = from Mimic in FieldRoot.Element("USER-INTERFACE-DEFINITION").Element("MIMICS").Descendants("MIMIC")
                                         .Where(e => e.Attribute("ID").Value == MIMIC_ID)
                                         from DataItem in Mimic.Descendants("SECTION")
                                         .Where(e => e.Attribute("ID").Value == SECTION_ID)
                                         .Descendants("DATAITEM").Where(e =>   
                                         e.Parent.Attribute("ID").Value == SECTION_ID)
                                         select DataItem;
