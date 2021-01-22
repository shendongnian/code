     public class FoobarIXml : IXmlSerializable
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public bool IsContent { get; set; }
            public DateTime BirthDay { get; set; }
    
            public XmlSchema GetSchema()
            {
                return null;
            }
    
            public void ReadXml(XmlReader reader)
            {
                reader.MoveToContent();
                var isEmptyElement = reader.IsEmptyElement;
                reader.ReadStartElement();
                if (!isEmptyElement)
                {
                    Name = reader.ReadElementString("Name");
    
                    int intResult;
                    var success = int.TryParse(reader.ReadElementString("Age"), out intResult);
                    if (success)
                    {
                        Age = intResult;
                    }
    
                    bool boolResult;
                    success = bool.TryParse(reader.ReadElementString("IsContent"), out boolResult);
                    if (success)
                    {
                        IsContent = boolResult;
                    }
                    DateTime dateTimeResult;
                    success = DateTime.TryParseExact(reader.ReadElementString("BirthDay"), "yyyy-MM-dd", null,
                        DateTimeStyles.None, out dateTimeResult);
                    if (success)
                    {
                        BirthDay = dateTimeResult;
                    }
                    reader.ReadEndElement(); //Must Do
                }
            }
    
            public void WriteXml(XmlWriter writer)
            {
                writer.WriteElementString("Name", Name);
                writer.WriteElementString("Age", Age.ToString());
                writer.WriteElementString("IsContent", IsContent.ToString());
                writer.WriteElementString("BirthDay", BirthDay.ToString("yyyy-MM-dd"));
            }
        }
    }
