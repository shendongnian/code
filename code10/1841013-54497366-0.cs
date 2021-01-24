using System.IO;
using System.Xml.Serialization;
namespace Serialization
{
    class Program
    {
        static string file = @"C:\employees.xml"; // Path to our XML file. Could be anything else.
        static void Main(string[] args)
        {
            Person[] people;
            XmlSerializer xmlser = new XmlSerializer(typeof(Person[])); // Our XML serializer!
            if (File.Exists(file)) // If the file exists read it
            {
                using (Stream s = File.OpenRead(file)) // We need a stream for our serializer
                {
                    people = (Person[])xmlser.Deserialize(s); // Don't forget to cast the result.
                }
            }
            else // If the file doesn't exist we generate new data
            {
                people = new Person[] { new Person("John", "Doe"), new Person("Joe", "Swanson") };
                using (Stream s = File.OpenWrite(file)) // And then we save our new data.
                {
                    xmlser.Serialize(s, people);
                }
            }
        }
        // And now that we have something in people you can use it as you wish to.
    }
    public class Person // Our data class. Has to be public.
    {
        public Person() { } // Parameterless constructor used by XmlSerializer. IMPORTANT!!!
        public Person(string firstName, string surName)
        {
            FirstName = firstName;
            SurName = surName;
        }
        public string FirstName { get; set; }
        public string SurName { get; set; }
    }
}
