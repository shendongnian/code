    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using ProtoBuf;
    static class Program
    {
        static void Main()
        {
            using (MemoryStream ms = new MemoryStream())
            {
                WriteNext(ms, 123);
                WriteNext(ms, new Person { Name = "Fred" });
                WriteNext(ms, "abc");
    
                ms.Position = 0;
    
                while (ReadNext(ms)) { }            
            }
        }
        static readonly IDictionary<int, Type> typeLookup = new Dictionary<int, Type>
        {
            {1, typeof(int)}, {2, typeof(Person)}, {3, typeof(string)}
        };
        static void WriteNext(Stream stream, object obj) {
            Type type = obj.GetType();
            int field = typeLookup.Single(pair => pair.Value == type).Key;
            Serializer.NonGeneric.SerializeWithLengthPrefix(stream, obj, PrefixStyle.Base128, field);
        }
        static bool ReadNext(Stream stream)
        {
            object obj;
            if (Serializer.NonGeneric.TryDeserializeWithLengthPrefix(stream, PrefixStyle.Base128, field => typeLookup[field], out obj))
            {
                Console.WriteLine(obj);
                return true;
            }
            return false;
        }
    }
    [ProtoContract] class Person {
        [ProtoMember(1)]public string Name { get; set; }
        public override string ToString() { return "Person: " + Name; }
    }
