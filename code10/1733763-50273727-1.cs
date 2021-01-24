    public class UserObject
    {
        [BsonIgnoreIfDefault]
        public ObjectId _id { get; set; }// Self generated
        public ulong UserID { get; set; } // Self generated
        public string Username { get; set; }
        public string CharClass{ get; set; }
        public int CharLevel { get; set; }
        public int CharColour { get; set; }
    }
