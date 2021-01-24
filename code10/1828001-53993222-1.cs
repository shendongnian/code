    public class ResponseWithQuestion
    {
        public string title { get; set; }
        public string type { get; set; }
        public List<object> options { get; set; }
        public object answer { get; set; }
        public bool? isInvisible { get; set; }
    }
    
    public class ResponseDetails
    {
        public List<ResponseWithQuestion> responseWithQuestions { get; set; }
    }
    
    public class Property
    {
        public string n { get; set; }
        public int t { get; set; }
        public string v { get; set; }
    }
    
    public class Data
    {
        public string actionId { get; set; }
        public string actionPackageId { get; set; }
        public string packageId { get; set; }
        public string groupId { get; set; }
        public string sourceGroupId { get; set; }
        public string responseId { get; set; }
        public bool isUpdateResponse { get; set; }
        public string responder { get; set; }
        public string responderId { get; set; }
        public string creatorId { get; set; }
        public string responderName { get; set; }
        public string responderProfilePic { get; set; }
        public bool isAnonymous { get; set; }
        public ResponseDetails responseDetails { get; set; }
        public List<Property> Properties { get; set; }
    }
    
    public class RootObject
    {
        public string subscriptionId { get; set; }
        public string objectId { get; set; }
        public string objectType { get; set; }
        public string eventType { get; set; }
        public string eventId { get; set; }
        public Data data { get; set; }
        public string context { get; set; }
        public string fromUser { get; set; }
        public string fromUserId { get; set; }
        public bool isBotfromUser { get; set; }
        public string fromUserName { get; set; }
        public string fromUserProfilePic { get; set; }
    }
    
