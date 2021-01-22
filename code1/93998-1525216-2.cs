    using System;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;
    using System.Runtime.Serialization;
    
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
    
                DataContractSerializer serializer=new DataContractSerializer(typeof(Person[]));
                using (var stream = new FileStream("persons.xml", FileMode.Create, FileAccess.Write))
                {
                    serializer.WriteObject(stream,persons);
                }
    
                Person[] restored_persons;
                using (var another_stream=new FileStream("persons.xml",FileMode.Open,FileAccess.Read))
                {
                    restored_persons = serializer.ReadObject(another_stream) as Person[];
                }
               
                foreach (var person in restored_persons)
                {
                    Console.WriteLine(person.ToString());
                }
                Console.ReadLine();
            }
        }
    
        [DataContract]
        public class Person
        {
            [DataMember]
            public string Name { get; set; }
            [DataMember]
            public string Password { get; set; }
            [DataMember]
            public string Email { get; set; }
            public override string ToString()
            {
                return string.Format("The person with name {0} has password {1} and email {2}",
                                     this.Name, this.Password, this.Email);
            }
        }
    }
