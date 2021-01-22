    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Formatters.Binary;
    
    [Serializable]
    public class Child
    {
        public Guid Id { get; set; }
    
        public Parent parent;
    }
    
    [Serializable]
    public class Parent
    {
        public Guid Id;
    
        public List<Child> Children;
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Child c1 = new Child { Id = Guid.NewGuid() };
            Child c2 = new Child { Id = Guid.NewGuid() };
    
            Parent p = new Parent { Id = Guid.NewGuid(), Children = new List<Child> { c1, c2 } };
    
            c1.parent = p;
            c2.parent = p;
    
            using (var stream1 = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream1, p);
                stream1.Position = 0;
    
                var deserializedParent = formatter.Deserialize(stream1) as Parent;
                foreach (var child in deserializedParent.Children)
                {
                    Console.WriteLine("Child Id: {0}, Parent Id: {1}", child.Id, child.parent.Id);
                }
            }
    
            Console.ReadLine();
        }
    }
