    public class Channel 
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public ObservableCollection<Channel> SubChannels { get; }
    }
