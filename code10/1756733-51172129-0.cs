    [ProtoContract(SkipConstructor=true)]
    public class Data
    {
        [ProtoMember(1)]
        public bool[] Flags;
    
        public Data()
        {
            Falgs = new bool[3] { true, true, true }
        }
    }
