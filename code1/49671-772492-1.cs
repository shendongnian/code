        static bool IsJpegHeader(string filename)
        {
            using (BinaryReader br = new BinaryReader(File.Open(filename, FileMode.Open)))
            {
                UInt16 soi = br.ReadUInt16();
                UInt16 jfif = br.ReadUInt16();
                return soi == 0xd8ff && jfif == 0xe0ff;
            }
        }
