      public class Courses
    {
     [Key]
    public int Course_Id{ get; set; }
     [ForeignKey("Student")]
    public int Student_Id{ get; set; }
     [StringLength(100)]
    public string CourseName{ get; set; }
     [StringLength(10)]
    public string Duration { get; set; }
    public virtual Student Student{ get; set;}
    }
