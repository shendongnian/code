    class Program
    {
        public static void Main()
        {
            var dico = new Dictionary<long, uint>();
            for (long i = 0; i < 7500000; i++)
            {
                dico.Add(i, (uint)i);
            }
    
            using (var stream = File.OpenWrite("data.dat"))
            using (var writer = new BinaryWriter(stream))
            {
                foreach (var key in dico.Keys)
                {
                    writer.Write(key);
                    writer.Write(dico[key]);
                }
            }
    
            dico.Clear();
            using (var stream = File.OpenRead("data.dat"))
            using (var reader = new BinaryReader(stream))
            {
                for (int i = 0; i < 7500000; i++)
                {
                    var key = reader.ReadInt64();
                    var value = reader.ReadUInt32();
                    dico.Add(key, value);
                }
            }
        }
    }
