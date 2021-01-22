    public enum PacketType { Undefined, LoginPacket, MovePacket }
    public class PacketData
    {
        public String Command;
        public String[] Arguments;
    }
    public class Packet
    {
        public readonly PacketType TypeOfPacket;
        private Dictionary<string, string> _argumentMap;
        public Packet(PacketType _packetType,
                      Dictionary<string, string> argumentMap)
        {
            TypeOfPacket = _packetType;
            _argumentMap = argumentMap;
        }
        public string this[string index]
        {
            get { return _argumentMap[index]; }
            set { _argumentMap[index] = value; }
        }
    }
    public static class PacketFactory
    {
        Packet GetInstance(PacketData packetData)
        {
            Dictionary<string, string> argumentMap
                                = new Dictionary<string, string>();
            PacketType typeOfPacket = PacketType.Undefined;
            
            // Replace inline strings/int with static/int string definitions
            switch (packetData.Command.ToUpper())
            {
                case "LOGIN":
                    typeOfPacket = PacketType.LoginPacket;
                    argumentMap["UserName"] = packetData.Arguments[0];
                    argumentMap["PassWord"] = packetData.Arguments[1];
                    break;
                case "MOVE":
                    typeOfPacket = PacketType.MovePacket;
                    //..
                    break;
                default:
                    throw new ArgumentException("Not a valid packet type");
            }
            return new Packet(typeOfPacket, argumentMap);
        }
    }
