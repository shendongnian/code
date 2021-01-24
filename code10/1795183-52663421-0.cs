    [ProtoContract]
    public class ProjectData
    {
        [ProtoMember(1, DataFormat = DataFormat.Grouped)]
        public List<SEModule> modules = new List<SEModule>();
    
        [ProtoMember(2)]
        public string projectName = "";
    }
