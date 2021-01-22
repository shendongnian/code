    public class Department
    {
        // Initialize the list inside Default Constructor
        public Department()
        {
            courses = new List<Course>();
        }
        // Initialize List By Declaring outside and Passing with Dpartment Initilization
        public Department(List<Course> _courses)
        {
            courses = _courses;
        }
        List<Course> courses;
        public List<Course> Courses
        {
            get
            {
                if (courses == null)
                    return new List<Course>();
                else return courses;
            }
            set { courses = value; }
        }
        internal bool AddCourseToCourses(Course _course)
        {
            bool isAdded = false;
            // DoSomeChecks here like
            if (!courses.Contains(_course))
            {
                courses.Add(_course);
                isAdded = true;               
            }
            return isAdded;
        }
    }
    
    public class Course
    { }
    public class Subject
    { }
    public class TestClass
    {
        public void DoSomething()
        {
            Department dept = new Department();
            // By using Property Course
            dept.Courses.Add(new Course());
            // Deliver authoroty to add Course to Department Class itself
            dept.AddCourseToCourses(new Course());
        }
    }
