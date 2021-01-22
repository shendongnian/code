    public class Util
    {
        static private T Load<T>(string xml)
        {
            T t;
    
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            try
            {
                System.Text.ASCIIEncoding  encoding=new System.Text.ASCIIEncoding();
                Byte[] bytes = encoding.GetBytes(xml);
                using (MemoryStream ms = new MemoryStream(bytes))
                {
                    t = (T)serializer.Deserialize(ms);
                }
            }
            catch (Exception ex) 
            {
                throw ex; // This part is for debugging
            }
    
            return t;
        }
    }
