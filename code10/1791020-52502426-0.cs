    public class Course
    {
      public int CourseID { get; set; }
      public string Title { get; set; }
      public int Credits { get; set; }
      public int DepartmentID { get; set; }
      public virtual Department Department { get; set; }
    }
