    public abstract class CourseBase {
       public string CID { get; set; }
       public string CName{ get; set; }
    }
    
    public class ResearchCourse : CourseBase { }
    public class TaughtCourse : CourseBase { }
