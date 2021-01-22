    using System;
    using System.Linq;
    using System.Xml.Linq;
    
    namespace SerializationTesting
    {
    
        class Person
        {
    
            // Notice how this object type uses private setters, something that the traditional XmlSerializer will complain about if you don't use a wrapper class..
            public string Name { get; private set; }
            public DateTime Birthday { get; private set; }
            public long HeightInMillimeters { get; private set; }
            public Gender Gendrality { get; private set; }
    
            // Generate a serialized XElement from this Person object.
            public XElement ToXElement()
            {
                return new XElement("person",
                    new XAttribute("name", Name),
                    new XAttribute("birthday", Birthday),
                    new XAttribute("heightInMillimeters", HeightInMillimeters),
                    new XAttribute("gendrality", (long)Gendrality)
                );
            }
    
            // Serialize this Person object to an XElement.
            public static Person FromXElement(XElement x)
            {
                return new Person(
                    (string)x.Attribute("name"),
                    (DateTime)x.Attribute("birthday"),
                    (long)x.Attribute("heightInMillimeters"),
                    (Gender)(long)x.Attribute("gendrality")
                );
            }
    
            public Person(string name, DateTime birthday, long heightInMillimeters, Gender gender)
            {
                Name = name;
                Birthday = birthday;
                HeightInMillimeters = heightInMillimeters;
                Gendrality = gender;
            }
    
            // You must override this in conjunction with overriding GetHashCode (below) if you want .NET collections (HashSet, List, etc.) to properly compare Person objects.
            public override bool Equals(object obj)
            {
                if (obj.GetType() == typeof(Person))
                {
                    Person objAsPerson = (Person)obj;
                    return Name == objAsPerson.Name && Birthday == objAsPerson.Birthday && HeightInMillimeters == objAsPerson.HeightInMillimeters && Gendrality == objAsPerson.Gendrality;
                }
                return false;
            }
    
            // You must override this in conjunction with overriding Equals (above) if you want .NET collections (HashSet, List, etc.) to properly compare Person objects.
            public override int GetHashCode()
            {
                return Name.GetHashCode() ^ Birthday.GetHashCode() ^ HeightInMillimeters.GetHashCode() ^ Gendrality.GetHashCode();
            }
    
            // This allows us to compare Person objects using the == operator.
            public static bool operator ==(Person a, Person b)
            {
                return a.Equals(b);
            }
    
            // This allows us to compate Person objects using the != operator.
            public static bool operator !=(Person a, Person b)
            {
                return !a.Equals(b);
            }
        }
    
        public enum Gender
        {
            Male,
            Female
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                // Create first person (note how UTC time saves and loads properly when casting).
                Person personOne = new Person("Alexandru", DateTime.UtcNow, 1000, Gender.Male);
                // Save the first person to a local file on the hard disk.
                personOne.ToXElement().Save("PersonOne.dat");
                // Create second person (not using UTC time this time around).
                Person personTwo = new Person("Alexandria", DateTime.Now, 900, Gender.Female);
                // Save the second person to a local file on the hard disk.
                personTwo.ToXElement().Save("PersonTwo.dat");
                // Load the first person from a local file on the hard disk.
                XDocument personOneDocument = XDocument.Load("PersonOne.dat");
                Person personOneLoadedFromDocument = Person.FromXElement(personOneDocument.Elements().First());
                // Load the second person from a local file on the hard disk.
                XDocument personTwoDocument = XDocument.Load("PersonTwo.dat");
                Person personTwoLoadedFromDocument = Person.FromXElement(personTwoDocument.Elements().First());
                // Serialize the first person to a string and then load them from that string.
                string personOneString = personOne.ToXElement().ToString();
                XDocument personOneDocumentFromString = XDocument.Parse(personOneString);
                Person personOneLoadedFromDocumentFromString = Person.FromXElement(personOneDocumentFromString.Elements().First());
                // Check for equalities between persons (all outputs will be "true").
                Console.WriteLine(personOne.Equals(personOneLoadedFromDocument));
                Console.WriteLine(personTwo.Equals(personTwoLoadedFromDocument));
                Console.WriteLine(personOne == personOneLoadedFromDocument);
                Console.WriteLine(personTwo == personTwoLoadedFromDocument);
                Console.WriteLine(personOne != personTwo);
                Console.WriteLine(personOneLoadedFromDocument != personTwoLoadedFromDocument);
                Console.WriteLine(personOne.Equals(personOneLoadedFromDocumentFromString));
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
            }
        }
    }
