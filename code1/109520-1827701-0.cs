    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.IO;
    
    class Program
    {
        [Serializable]
        class Relation
        {
        }
    
        [Serializable]
        class Person : ISerializable
        {
            private Dictionary<Relation, List<int>> Relationships = new Dictionary<Relation, List<int>>();
    
            public Person() {}
    
            public void AddRelationship() {
                Relationships.Add(new Relation(), new List<int>());
            }
    
            public int CountRelations()
            {
                return Relationships.Count;
            }
    
            /*
            public Person(SerializationInfo info, StreamingContext context)
            {
                this.Relationships = (Dictionary<Relation, List<int>>)info.GetValue("Relationships", typeof(Dictionary<Relation, List<int>>));
            }
    
            public void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                info.AddValue("Relationships", this.Relationships);
            }
             * */
        }
    
        public static void Main()
        {
            Person person = new Person();
            person.AddRelationship();
            BinaryFormatter formatter = new BinaryFormatter();
            MemoryStream stream = new MemoryStream();
            formatter.Serialize(stream, person);
            stream.Seek(0, SeekOrigin.Begin);
            person = (Person)formatter.Deserialize(stream);
            Console.WriteLine("Count: " + person.CountRelations());
        }
    }
