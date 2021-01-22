    public struct Packet    
    {    
        public byte STX;    
        public UInt16 DataLength;    
        public string Data;    
        public byte CRC;    
        public byte ETX;    
    }    
    
    public static class StreamExtensions
    {
        public IEnumerable<Packet> ToPacketStream(this Stream stream)
        {
            BinaryReader reader = new BinaryReader(stream);
            while(reader.PeekChar() != -1) //Optionally change this to reflect your exit conditions
            {
                var packet = new Packet();
                packet.STX =        _reader.ReadByte();       
                packet.DataLength = _reader.ReadUInt16();       
                packet.Data =       Encoding.ASCII.GetString(_reader.ReadBytes(packet.DataLength));       
                packet.CRC =        _reader.ReadByte();       
                packet.ETX =        _reader.ReadByte();
                yield return packet;
            }
        }   
    }
    //Usage
    foreach(var packet in stream.ToPacketStream())
    {
        //Handle packet
    }
