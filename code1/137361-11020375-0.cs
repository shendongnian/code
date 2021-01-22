    using System;
    using System.Xml.Serialization;
    using System.IO;
    
    public class Test
    {
        public static void Main()
        {
            Sub subInstance = new Sub();
            Console.WriteLine(subInstance.TestMethod());
        }
         
        public class Super
        {
            public string TestMethod() {
                return this.SerializeObject();
            }
        }
         
        public class Sub : Super
        {
        }
    }
    
    public static class TestExt {
        public static string SerializeObject<T>(this T toSerialize)
        {
            Console.WriteLine(typeof(T).Name);             // PRINTS: "Super", the base/superclass -- Expected output is "Sub" instead
            Console.WriteLine(toSerialize.GetType().Name); // PRINTS: "Sub", the derived/subclass
            
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            StringWriter textWriter = new StringWriter();
    
            // And now...this will throw and Exception!
            // Changing new XmlSerializer(typeof(T)) to new XmlSerializer(subInstance.GetType()); 
            // solves the problem
            xmlSerializer.Serialize(textWriter, toSerialize);
            return textWriter.ToString();
        }
    }
