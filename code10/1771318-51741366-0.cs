    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XmlReader reader = XmlReader.Create(FILENAME);
                while (!reader.EOF)
                {
                    if (reader.Name != "contact")
                    {
                        reader.ReadToFollowing("contact");
                    }
                    if (!reader.EOF)
                    {
                        XElement xContact = (XElement)XElement.ReadFrom(reader);
                        Contact newContact = new Contact();
                        Contact.contacts.Add(newContact);
                        newContact.attributes = xContact.Descendants("attribute")
                            .GroupBy(x => (string)x.Element("name"), y => (string)y.Element("value"))
                            .ToDictionary(x => x.Key, y => y.FirstOrDefault());
                    }
                }
            }
        }
        public class Contact
        {
            public static List<Contact> contacts = new List<Contact>();
            public Dictionary<string, string> attributes { get; set; }
        }
     }
