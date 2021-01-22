    public static string ObjectToXML(Type type, object obby)
    {
        XmlSerializer ser = new XmlSerializer(type);
        using (System.IO.MemoryStream stm = new System.IO.MemoryStream())
        {
            //serialize to a memory stream
            ser.Serialize(stm, obby);
            //reset to beginning so we can read it.  
            stm.Position = 0;
            //Convert a string. 
            using (System.IO.StreamReader stmReader = new System.IO.StreamReader(stm))
            {
                string xmlData = stmReader.ReadToEnd();
                return xmlData;
            }
        }
    }
    public static object XmlToObject(Type type, string xml)
    {
        object oOut = null;
        //hydrate based on private string var
        if (xml != null && xml.Length > 0)
        {
            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(type);
            using (System.IO.StringReader sReader = new System.IO.StringReader(xml))
            {
                oOut = serializer.Deserialize(sReader);
                sReader.Close();
            }
        }
        return oOut;
    }
