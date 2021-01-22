    [DataContract]
    class Conversation
    {
        private string convName, convOwner;
        public ArrayList convUsers;
    
        [DataMember]
        public string ConvName
        {
           get { return this.convName; }
        }
        [DataMember]
        public string ConvOwner
        {
           get { return this.convOwner; }
        }
    }
