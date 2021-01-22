    [XmlRoot("StatusUpdate")]
    public class StatusUpdate
    {
        public StatusUpdate()
        {
            
        }
        [XmlArray("Players"), XmlArrayItem(ElementName = "Player", Type = typeof(PlayerInfo))]
        public PlayerInfo[] Players { get; set; }
        [XmlElement("Command")]
        public ServerCommand Update { get; set; }
    }
