    public class Message
    {
      public string[] registration_ids { get; set; }
      public Notification notification { get; set; }
      public object data { get; set; }
    }
      public class Notification
    {
       public string title { get; set; }
       public string text { get; set; }
    }
