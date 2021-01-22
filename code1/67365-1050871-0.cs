    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;
    
    [XmlRoot("Foolist")]
    public class Record
    {
        public Record(string name)
            : this()
        {
            Name = name;
        }
        public Record() { Children = new List<Record>(); }
        [XmlAttribute("name")]
        public string Name { get; set; }
    
        [XmlElement("Child")]
        public List<Record> Children { get; set; }
    }
    
    static class Program
    {
        static void Main()
        {
            Record root = new Record {
                Children = {
                    new Record("A") {
                        Children = {
                            new Record("Child 1"),
                            new Record("Child 2"),
                        }
                    }, new Record("B"),
                    new Record("C") {
                        Children = {
                            new Record("Child 1") {
                                Children = {
                                    new Record("Little 1")
                                }
                            }
                        }
                    }}
                };
            var ser = new XmlSerializer(typeof(Record));
            ser.Serialize(Console.Out, root);
        }
    }
