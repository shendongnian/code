    public static string SerializeDTO(DTO dto) 
    {
        try {
            XmlSerializer xmlSer = new XmlSerializer(dto.GetType());
            StringWriter sWriter = new StringWriter();
            xmlSer.Serialize(sWriter, dto);
            return sWriter.ToString();
        }
    catch(Exception ex) 
    {
    
    string message = String.Format("Something went wrong when serializing DTO {0}", DTO)        
    throw new Execption(message, ex);
    
    }
 }
