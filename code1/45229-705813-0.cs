    public partial class Course
    {
       public Category Category
       {
          get { return this.CourseCategories.SingleOrDefault().Category; }
       }
    }
