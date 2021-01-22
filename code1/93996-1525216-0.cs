    using System;
    using System.Linq;
    using System.Xml.Linq;
    
    namespace XmlSerialization
    {
        class Program
        {
            static void Main(string[] args)
            {
                var person1 = new Person();
                person1.Name = "Joe";
                person1.Password = "Cla$$ified";
                person1.Email = "none@your.bussiness";
    
                var person2 = new Person();
                person2.Name = "Doe";
                person2.Name = "$ecret";
                person2.Email = "dont@spam.me";
    
                var persons = new[] {person1, person2};
    
                XElement xml = new XElement("persons",
                                            from person in persons
                                            select new XElement("person",
                                                                new XElement("name", person.Name),
                                                                new XElement("password", person.Password),
                                                                new XElement("email", person.Email))
                                            );
                xml.Save("persons.xml");
    
                XElement restored_xml = XElement.Load("persons.xml");
                Person[] restored_persons = (from person in restored_xml.Elements("person")
                                             select new Person
                                                        {
                                                            Name = (string)person.Element("name"),
                                                            Password = (string)person.Element("password"),
                                                            Email = (string)person.Element("email")
                                                        })
                                            .ToArray();
                foreach (var person in restored_persons)
                {
                    Console.WriteLine(person.ToString());
                }
                Console.ReadLine();
        }
    }
    public class Person
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public override string ToString()
        {
            return string.Format("The person with name {0} has password {1} and email {2}",
                                 this.Name, this.Password, this.Email);
        }
    }
}
