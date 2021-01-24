    public class ChannelHandler
    {
        public ChannelName ChannelName { get; set; }
        public ParentId ParentId { get; set; }
        public List<ChildId> ChildIds { get; set; }
        public int Id;
        public ChannelHandler(ChannelName name, int id)
        {
            ChannelName = name;
            Id = id;
        }
        public ChannelHandler(ChannelName name, int id, ParentId parentid)
        {
            ChannelName = name;
            Id = id;
            ParentId = parentid;
        }
