    public class LogonChallenge
    {
        public LogonChallenge(BinaryReader data)
        {
            // header
            this.Cmd = data.ReadByte();
            this.Error = data.ReadByte();
            this.Size = data.ReadUInt16();
    
            // etc
        }
    }
