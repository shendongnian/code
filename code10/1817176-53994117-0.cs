     [DataContract]
    public  class Player
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Sport { get; set; }
    }
    [DataContract]
    public class SportType
    {
        [DataMember]
        public string Type { get; set; }
        [DataMember]
        public List<Player> Players { get; set; }
    }
                  // name is the root xml element, itemName is the name of item xml element
    [CollectionDataContract(Name = "SportTypes", ItemName = "SportType")]
    public class SportTypeCollection : IEnumerable<SportType>
    {
        public IList<SportType> SportTypes { get;private set; }
        public IEnumerator<SportType> GetEnumerator()
        {
            return this.SportTypes.GetEnumerator();
        }
        public SportTypeCollection(params SportType[] sportTypes)
        {
            if (null == sportTypes)
            {
                this.SportTypes = new List<SportType>();
            }
            else
            {
                this.SportTypes = sportTypes;
            }
        }
        public SportTypeCollection()
        {
            this.SportTypes = new List<SportType>();
        }
        public void Add(SportType sportType)
        {
            this.SportTypes.Add(sportType);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.SportTypes.GetEnumerator();
        }
    }
