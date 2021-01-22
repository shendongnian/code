    struct Packet
    {
        public byte STX;
        public UInt16 DataLength;
        public string Data;
        public byte CRC;
        public byte ETX;
    }
    
    //Warning: Need to add error handling
    class PacketReader
    {
        private BinaryReader _reader;
    
        public PacketReader(Stream stream)
        {
            _reader = new BinaryReader(stream);
        }
    
        Packet ReadPacket()
        {
            var packet = new Packet() 
                {
                    STX = _reader.ReadByte(),
                    DataLength = _reader.ReadUInt16(),
                    Data = Encoding.ASCII.GetString(
                        _reader.ReadBytes(packet.DataLength)),
                    CRC = _reader.ReadByte(),
                    ETX = _reader.ReadByte()
                };
    
            return packet;
        }
    }
