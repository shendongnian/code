    /// <summary>
    /// Utilities for reading big-endian files
    /// </summary>
    public class BigEndianReader
    {
        public BigEndianReader(BinaryReader baseReader)
        {
            mBaseReader = baseReader;
        }
        public short ReadInt16()
        {
            return BitConverter.ToInt16(ReadBigEndianBytes(2), 0);
        }
        public ushort ReadUInt16()
        {
            return BitConverter.ToUInt16(ReadBigEndianBytes(2), 0);
        }
        public uint ReadUInt32()
        {
            return BitConverter.ToUInt32(ReadBigEndianBytes(4), 0);
        }
        
        public byte[] ReadBigEndianBytes(int count)
        {
            byte[] bytes = new byte[count];
            for (int i = count - 1; i >= 0; i--)
                bytes[i] = mBaseReader.ReadByte();
            return bytes;
        }
        public byte[] ReadBytes(int count)
        {
            return mBaseReader.ReadBytes(count);
        }
        public void Close()
        {
            mBaseReader.Close();
        }
        public Stream BaseStream
        {
            get { return mBaseReader.BaseStream;  }
        }
        private BinaryReader mBaseReader;
    }
