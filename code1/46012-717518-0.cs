    public class XmlException: Exception{
       ....
    } 
    
    public class XmlParser{
       public void Parse()
       {
          try{
              ....
          }
          catch(IOException ex)
          {
             throw new XmlException("IO Error while Parsing", ex );
          }
       }
    }
