     public static class AppExtensions
     {                                                                      
           public static T DeepClone<T>(this T a)
           {
               using (var stream = new MemoryStream())
               {
                   var serializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
    
                   serializer.Serialize(stream, a);
                   stream.Position = 0;
                   return (T)serializer.Deserialize(stream);
               }
           }                                                                    
     }
