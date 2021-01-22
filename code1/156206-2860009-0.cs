    using System;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.Xml.Serialization;
    using System.IO;
    using System.Diagnostics;
    using System.Collections.Generic;
    
    namespace ConsoleApplication1
    {
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "",
            IsNullable = false)]
        public class DataSet
        {
            public User User { get; set; }
        }
    
        public class User
        {
            public string UserName { get; set; }
            public string Email { get; set; }
    
            [System.Xml.Serialization.XmlElementAttribute("Details")]
            public Details[] Details { get; set; }
        }
    
        public class Details
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string Value { get; set; }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                string xmlFragment =
                    @"<DataSet>
                      <User>
                        <UserName>Test</UserName>
                        <Email>test@test.com</Email>
                        <Details>
                          <ID>1</ID>
                          <Name>TestDetails</Name>
                          <Value>1</Value>
                        </Details>
                        <Details>
                          <ID>2</ID>
                          <Name>Testing</Name>
                          <Value>3</Value>
                        </Details>
                      </User>
                    </DataSet>";
    
                StringReader reader = new StringReader(xmlFragment);
                XmlSerializer xs = new XmlSerializer(typeof(DataSet));
                DataSet ds = xs.Deserialize(reader) as DataSet;
                
                User user = ds.User;
                Console.WriteLine("User name: {0}", user.UserName);
                Console.WriteLine("Email: {0}", user.Email);
    
                foreach (Details detail in user.Details)
                {
                    Console.WriteLine("Detail [ID]: {0}", detail.ID);
                    Console.WriteLine("Detail [Name]: {0}", detail.Name);
                    Console.WriteLine("Detail [Value]: {0}", detail.Value);
                }
                
                // pause program execution to review results...
                Console.WriteLine("Press enter to exit");
                Console.ReadLine();
            }
        }
    }
