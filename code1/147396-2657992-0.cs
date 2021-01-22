        private static void write()
        {
            List<string> list = new List<string>();
            list.Add("ab");
            list.Add("db");
            Stream stream = new FileStream("D:\\Bar.dat", FileMode.Create);
            BinaryWriter binWriter = new BinaryWriter(stream);
            binWriter.Write(list.Count);
            foreach (string _string in list)
            {
                binWriter.Write(_string);
            }
            binWriter.Close();
            stream.Close();
        }
        private static void read()
        {
            List<string> list = new List<string>();
            Stream stream = new FileStream("D:\\Bar.dat", FileMode.Open);
            BinaryReader binReader = new BinaryReader(stream);
            int pos = 0;
            int length = binReader.ReadInt32();
            while (pos < length)
            {
                list.Add(binReader.ReadString());
                pos ++;
            }
            binReader.Close();
            stream.Close();
        }
