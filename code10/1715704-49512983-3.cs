    public class SmsDto
    {
       public MessageDto message { get; set; }
    
       public List<string> endpoints { get; set; }
    }
    
    public class MessageDto
    {
       public string text { get; set; }
    }
