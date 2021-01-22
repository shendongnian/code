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
                dept.Courses.Add(new Course());
            }
        }
