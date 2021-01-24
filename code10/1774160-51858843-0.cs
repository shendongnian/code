    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    namespace ConsoleApplication1
    {
        public class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            public static void Main()
            {
                XmlReader reader = XmlReader.Create(FILENAME);
                XmlSerializer serializer = new XmlSerializer(typeof(Berserker));
                Berserker berserker = (Berserker)serializer.Deserialize(reader);
     
            }
        }
        public class Berserker
        {
             public string Name { get; set;}
             public int Strength { get; set;}
             public int Dexterity { get; set;}
             public int Wisdom { get; set;}
             public int Health { get; set;}
             public string Gender { get; set;}
             public string CharacterClass { get; set; }
        }
    }
