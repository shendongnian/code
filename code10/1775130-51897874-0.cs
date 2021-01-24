    Attachment deserializedAttachement = new Attachment();  
    MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(item[6]));  
    DataContractJsonSerializer ser = new DataContractJsonSerializer(deserializedAttachment.GetType());  
    deserializedAttachment = ser.ReadObject(ms) as Attachment;  
    ms.Close();
