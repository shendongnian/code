        public IEnumerable<Byte> ReadFile(String fileName)
        {
            using (FileStream file = new FileStream(fileName, FileMode.Open))
            {
                Int32 byteRead;
                while ((byteRead = file.ReadByte()) != -1)
                {
                    yield return (Byte)byteRead;
                }
            }
        }
