    using (var reader = new BinaryReader(new FileStream(@"D:\testlog.log", FileMode.Open, FileAccess.Read, FileShare.ReadWrite)))
    {
        string s;
        while (Console.ReadLine() != "exit")
        {
            // allocate buffer for new ints
            Int32[] buffer = new Int32[(reader.BaseStream.Length - reader.BaseStream.Position) / sizeof(Int32)];
            Console.WriteLine("Stream length: {0}", reader.BaseStream.Length);
            Console.Write("Ints read: ");
            for (int i = 0; i < buffer.Length; i++)
            {
                buffer[i] = reader.ReadInt32();
                Console.Write((i == 0 ? "" : ", ") + buffer[i].ToString());
            }
            Console.WriteLine();
        }
    }
