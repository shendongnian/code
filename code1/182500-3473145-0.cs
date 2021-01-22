    public interface MXmlSerializable { } 
    public static class XmlSerializable {
      public static string ToXml(this MXmlSerializable self) {     
        if (self == null) throw new ArgumentNullException();     
        var serializer = new XmlSerializer(self.GetType());     
        using (var writer = new StringWriter()) {       
          serializer.Serialize(writer, self);       
          return writer.GetStringBuilder().ToString();     
        }   
      }   
    }
    public class Customer : MXmlSerializable {   
      public string Name { get; set; }   
      public bool Preferred { get; set; } 
    }
    // ....
    var customer = new Customer {    
      Name = "Guybrush Threepwood",    
      Preferred = true }; 
    var xml = customer.ToXml();
