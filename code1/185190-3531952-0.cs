    public class ColumnMap
    {
        public static explicit operator ColumnMap(XElement xElem)
        {
            return new ColumnMap()
            {
                DatabaseColumn = new Column()
                {
                    Name = xElem.Element("DatabaseColumn").Attribute("Name").Value
                }
            };
        }
    }
    public class ImportDefinition
    {
        public static explicit operator ImportDefinition(XElement xElem)
        {
            return new ImportDefinition() 
            { 
                Name           = (string)xElem.Attribute("Name"), 
                TypeName       = (string)xElem.Attribute("TypeName"), 
                Size           = (int)xElem.Attribute("Size"), 
                LastModified   = (DateTime?)xElem.Attribute("LastModified"), 
                ColumnMappings = xElem.Descendants("ColumnMap").Cast<ColumnMap>.ToList()
            }; 
        }
    }
