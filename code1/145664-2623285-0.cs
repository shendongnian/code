    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.IO;
    
    namespace NGTests
    {
      class Program
      {
        static void Main(string[] args)
        {
          Person p1 = new Person() { FirstName = "Chris", LastName = "Taylor", Children = { new Person() { FirstName = "Tamrin", LastName = "Taylor" } } };
          Person p2 = new Person() { FirstName = "Chris", LastName = "Taylor", Children = { new Person() { FirstName = "Tamrin", LastName = "Taylor" } } };
    
          BinaryFormatter formatter = new BinaryFormatter();
          
          MemoryStream ms1 = new MemoryStream();
          formatter.Serialize(ms1, p1);
          
          MemoryStream ms2 = new MemoryStream();
          formatter.Serialize(ms2, p2);
    
          byte[] b1 = ms1.ToArray();
          byte[] b2 = ms2.ToArray();
    
          Console.WriteLine("Objects are Equal : {0}", b1.SequenceEqual(b2));
    
          Console.ReadKey();
        }
      }
    
      [Serializable]
      class Person
      {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        public List<Person> Children { get; private set; }
    
        public Person()
        {
          Children = new List<Person>();
        }
      }
    }
