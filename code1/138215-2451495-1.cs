    public class Packet
    {
        public String Command;
        public String[] Arguments;
    }
    
    public abstract class AbstractPacket
    {
        private Packet _packet;
    
        public AbstractPacket(Packet packet)
        {
            _packet = packet;
        }
    
        public string this[int index]
        {
            get { return _packet.Arguments[index]; }
            set { _packet.Arguments[index] = value; }
        }
    }
    
    public class LoginPacket : AbstractPacket
    {
        public LoginPacket(Packet packet): base(packet)
        {            
        }
    
        public string Username
        {
            get { return base[0]; }
            set { base[0] = value; }
        }
        public string Password
        {
            get { return base[1]; }
            set { base[1] = value; }
        }
    
    }
