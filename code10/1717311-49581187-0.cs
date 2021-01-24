    public class College
    {
     //...
    
     public ICollection<Notice> Notice{ get; set; }
    }
    public class Notice
    {
     //...
    
     [ForeignKey("College")]
     public int CollegeId { get; set; }
     public College College { get; set; }
    }
