    class Item
    {
         public Announcement Announcement {get; set;} // your inner object, might be null
         ...
    }
    class Announcement
    {
         public DateTime CreatedDate {get; set;}
         ...
    }
