    using System;
    using System.Linq;
    using System.Xml.Linq;
    
    class Test
    {
        static void Main()
        {
            var doc = XDocument.Load("test.xml");
            var targetInstitution = "Division1";
            
            var users =
                from person in doc.Root.Elements("person")
                let name = person.Element("name").Element("n")
                let institution = person
                    .Element("extension")
                    .Elements("institutions")
                    .Elements("institution")
                    .SingleOrDefault(ins => (string) ins.Attribute("institution") == targetInstitution)
                // Only include users where we've foudn the institution
                where institution != null
                select new
                {
                    UserRole = (string) institution.Element("role"),
                    UserFirstName = (string) name.Element("given"),
                    UserLastName = (string) name.Element("family")
                };
            
            foreach (var user in users)
            {
                Console.WriteLine(user);
            }
        }
    }
