        public static void WriteToFile(FileStream stream, string destinationFile, int bufferSize = 4096, FileMode mode = FileMode.OpenOrCreate, FileAccess access = FileAccess.ReadWrite, FileShare share = FileShare.ReadWrite)
        {
            using (var destinationFileStream = new FileStream(destinationFile, mode, access, share))
            {
                while (stream.Position < stream.Length) 
                {
                    destinationFileStream.WriteByte((byte)stream.ReadByte());
                }
            }
        }
