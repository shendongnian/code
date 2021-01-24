    public class PolstForm
    {
        public int StatusCode { get; set; }
        public CustomData[] Data { get; set; }
    }
    
    public class CustomData
    {
        public int MemberId {get;set;}
        public int CreaterUserId {get;set;}
        public string FirstName {get;set;}
        public string LastName {get;set;}
        public string Title {get;set;}
        public string License {get;set;}
        public string Email {get;set;}
        public string PhoneNumber {get;set;}
        public bool IsSign {get;set;}
        public bool IsMemberActive {get;set;}
        public DateTime CreatedDate {get;set;}
        public string PhotoPath {get;set;}
    }
