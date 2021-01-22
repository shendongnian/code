        protected byte[] ExtractAudio(Stream stream)
        {
            var reader = new BinaryReader(stream);
            // Is stream a Flash Video stream
            if (reader.ReadChar() != 'F' || reader.ReadChar() != 'L' || reader.ReadChar() != 'V')
                throw new IOException("The file is not a FLV file.");
            // Is audio stream exists in the video stream
            var version = reader.ReadByte();
            var exists = reader.ReadByte();
            if ((exists != 5) && (exists != 4))
                throw new IOException("No Audio Stream");
            reader.ReadInt32(); // data offset of header. ignoring
            var output = new List<byte>();
            while (true)
            {
                try
                {
                    reader.ReadInt32(); // PreviousTagSize0 skipping
                    var tagType = reader.ReadByte();
                    while (tagType != 8)
                    {
                        var skip = ReadNext3Bytes(reader) + 11;
                        reader.BaseStream.Position += skip;
                        tagType = reader.ReadByte();
                    }
                    var DataSize = ReadNext3Bytes(reader);
                    reader.ReadInt32(); //skip timestamps 
                    ReadNext3Bytes(reader); // skip streamID
                    reader.ReadByte(); // skip audio header
                    for (int i = 0; i < DataSize - 1; i++)
                        output.Add(reader.ReadByte());
                }
                catch
                {
                    break;
                }
            }
            return output.ToArray();
        }
        private long ReadNext3Bytes(BinaryReader reader)
        {
            try
            {
                return Math.Abs((reader.ReadByte() & 0xFF) * 256 * 256 + (reader.ReadByte() & 0xFF)
                    * 256 + (reader.ReadByte() & 0xFF));
            }
            catch
            {
                return 0;
            }
        }
