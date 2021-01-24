    public class ChannelSettings
    {
        public string channel { get; set; }
        public string username { get; set; }
        public string text { get; set; }
        public Dictionary<string, string> attachments { get; set; } 
    }
    public ChannelSettings GetData()
    {
        return new ChannelSettings
        {        
            channel="one", username="user", text="text",
            attachments= new Dictionary<string, string>()
            {
                {"fallback","somevalue"},
                {"author_name","some author"},
                {"shoe_size","12},
                //...etc...
            }
        }
    }
    
    public string GenJSON(ChannelSettings channelSet)
    {
        string output = JsonConvert.SerializeObject(channelSet);
        return output;
    }
