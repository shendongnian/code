        public long ReadList(string fileName, Action<string> action,long position=0)
        {
            if (!File.Exists(fileName)) return 0;
            using (var reader = new StreamReader(File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite),System.Text.Encoding.Unicode))
            {
                if (position > 0)reader.BaseStream.Position = position;
                while (!reader.EndOfStream)
                {
                    action(reader.ReadLine());
                }
                return reader.BaseStream.Position;
            }
        }
