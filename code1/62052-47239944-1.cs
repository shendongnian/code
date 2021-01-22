        static private bool FileEquals(string file1, string file2)
        {
            using (FileStream s1 = new FileStream(file1, FileMode.Open, FileAccess.Read, FileShare.Read))
            using (FileStream s2 = new FileStream(file1, FileMode.Open, FileAccess.Read, FileShare.Read))
            using (BinaryReader b1 = new BinaryReader(s1))
            using (BinaryReader b2 = new BinaryReader(s2))
            {
                while (true)
                {
                    byte[] data1 = b1.ReadBytes(64 * 1024);
                    byte[] data2 = b2.ReadBytes(64 * 1024);
                    if (data1.Length != data2.Length)
                        return false;
                    if (data1.Length == 0)
                        return true;
                    if (!data1.SequenceEqual(data2))
                        return false;
                }
            }
        }
