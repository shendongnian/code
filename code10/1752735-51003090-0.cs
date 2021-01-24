    public class ChannelHandler
    {
        public ChannelName channelname { get; set; }
        public ParentId parentid { get; set; }
        public ChildIds list_of_childs { get; set; }
        public int id;
        public ChannelHandler(ChannelName name, int id)
        {
            this.channelname = name;
            this.id = id;
        }
        public ChannelHandler(ChannelName name, int id, ParentId parentid)
        {
            this.channelname = name;
            this.id = id;
            this.parentid = parentid;
        }
    }
