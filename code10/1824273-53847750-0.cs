    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml;
    using System.Xml.Serialization;
    
    namespace soXmlParsing
    {
        class Program
        {
            static void Main(string[] args)
            {
    
                using (var sreader = new StringReader(File.ReadAllText(@"C:\Users\JP\source\repos\soXmlParsing\soXmlParsing\XMLFile1.xml")))
                using (var reader = XmlReader.Create(sreader))
                {
                    var serializer = new XmlSerializer(typeof(response));
                    var test = (response)serializer.Deserialize(reader);
                    Console.WriteLine(test.operation.result.data.customer.PARENTNAME.ToString());
                    Console.WriteLine(test.operation.result.data.customer.DISPLAYCONTACTCONTACTNAME);
                }
            }
        }
        // could not fit auto gen code... 
        // Body is limited to 30000 characters; you entered 93977
    }
    
