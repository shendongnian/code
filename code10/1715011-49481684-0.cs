    public static void SaveXml(string FileName)  
        {  
            System.Xml.Serialization.XmlSerializer writer =   
                new System.Xml.Serialization.XmlSerializer(typeof(PhoneBook));  
    
            System.IO.FileStream file = System.IO.File.Create(path);  
    
            writer.Serialize(file, overview);  
            file.Close();  
        }  
