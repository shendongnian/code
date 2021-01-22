    using System.Collections.Generic;
    using ProtoBuf;
    using System.IO;
    
    [ProtoContract]
    class Test
    {
        [ProtoMember(1)]
        public Dictionary<long, uint> Data {get;set;}
    }
    
    class Program
    {
        public static void Main()
        {
            Serializer.PrepareSerializer<Test>();
            var dico = new Dictionary<long, uint>();
            for (long i = 0; i < 7500000; i++)
            {
                dico.Add(i, (uint)i);
            }
            var data = new Test { Data = dico };
            using (var stream = File.OpenWrite("data.dat"))
            {
                Serializer.Serialize(stream, data);
            }
            dico.Clear();
            using (var stream = File.OpenRead("data.dat"))
            {
                Serializer.Merge<Test>(stream, data);
            }
        }
    }
