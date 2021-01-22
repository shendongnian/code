    struct Packet
    {
        public byte STX;
        public UInt16 DataLength;
        public string Data;
        public byte CRC;
        public byte ETX;
    }
    //Warning: Need to add error handling
    class StreamPacket
    {
        private BinaryReader _reader;
        public StreamPacket(Stream stream)
        {
            _reader = new BinaryReader(stream);
        }
        Packet ToPacket()
        {
            var packet = new Packet();
            packet.STX = _reader.ReadByte();
            packet.DataLength = _reader.ReadUInt16();
            packet.Data = Encoding.ASCII.GetString(
                _reader.ReadBytes(packet.DataLength));
            packet.CRC = _reader.ReadByte();
            packet.ETX = _reader.ReadByte();
            return packet;
        }
    }
