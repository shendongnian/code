    string xml = "<Company><Tables><Agri><Tables><Table Id=\"1\"></Table></Tables><Tables><Table Id=\"2\"></Table></Tables></Agri><Tables><Table Id=\"3\"></Table></Tables><Tables><Table Id=\"4\"></Table></Tables></Tables></Company>";
    
    XmlSerializer sx = new XmlSerializer(typeof(Company));
    
    Company company = null;
    using (MemoryStream ms = new MemoryStream())
    {
    	ms.Write(Encoding.UTF8.GetBytes(xml), 0, Encoding.UTF8.GetBytes(xml).Length);
    
    	ms.Flush();
    
    	ms.Seek(0, SeekOrigin.Begin);
    
    	company = (Company)sx.Deserialize(ms);
    }
