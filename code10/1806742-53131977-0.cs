    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    namespace TP3
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                Zoo vincennes = new Zoo();
                Cow cow1 = new Cow("cow 1");
                Cow cow2 = new Cow("cow 2");
                vincennes.add(new Lion("lion 1"));
                vincennes.add(cow1);
                vincennes.add(new Lizard("lizard 1"));
                vincennes.add(new Platypus("platypus 1"));
                vincennes.add(new Snake("snake 1"));
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                XmlWriter writer = XmlWriter.Create(FILENAME,settings);
                XmlSerializer serializer = new XmlSerializer(typeof(Zoo));
                serializer.Serialize(writer, vincennes);
                System.Console.Read();
            }
        }
        public class Zoo
        {
            private List<IAnimal> animals = new List<IAnimal>();
            
            public void add(IAnimal animal)
            {
                animals.Add(animal);
            }
            public List<IAnimal> _animals
            {
                get { return animals; }
            }
        }
        [XmlInclude(typeof(IMammal))]
        [XmlInclude(typeof(IReptile))]
        public class IAnimal
        {
            protected string Name;
            public IAnimal()
            {
            }
            public string _name
            {
                get { return Name; }
            }
        }
        [XmlInclude(typeof(Cow))]
        [XmlInclude(typeof(Lion))]
        [XmlInclude(typeof(Platypus))]
        public class IMammal : IAnimal
        {
        }
        [XmlInclude(typeof(Snake))]
        [XmlInclude(typeof(Lizard))]
        public class IReptile : IAnimal
        {
        }
        public class Lizard : IReptile
        {
            public Lizard() { }
            public Lizard(string name)
            {
                Name = name;
            }
        }
        public class Snake : IReptile
        {
            public Snake() { }
            public Snake(string name)
            {
                Name = name;
            }
        }
        public class Cow : IMammal
        {
            public Cow() { }
            public Cow(string name)
            {
                Name = name;
            }
        }
        public class Lion : IMammal
        {
            public Lion(){}
            public Lion(string name)
            {
                Name = name;
            }
        }
        public class Platypus : IMammal
        {
            public Platypus() { }
            public Platypus(string name)
            {
                Name = name;
            }
        }
    }
