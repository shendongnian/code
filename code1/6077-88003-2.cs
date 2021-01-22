    using System;
    using System.IO;
    using System.Text;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Formatters.Binary;
    
    
    public static string SerializeToXMLString(object ObjectToSerialize)
    {
        MemoryStream mem = new MemoryStream();			
        System.Xml.Serialization.XmlSerializer ser = new System.Xml.Serialization.XmlSerializer(ObjectToSerialize.GetType());			
        ser.Serialize(mem,ObjectToSerialize);						
        ASCIIEncoding ascii = new ASCIIEncoding();
        return ascii.GetString(mem.ToArray());
    }
        
