    public class Department
    {
        // Initialize the list inside Default Constructor
        public Department()
        {            courses = new List<Course>();        }
    
        // Initialize List By Declaring outside and Passing with Dpartment Initilization
        public Department(List<Course> _courses)
        {            courses = _courses;        }
    
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
    {
        public Course(List<Subject> _subject)
        {            subjects = _subject;        }
        List<Subject> subjects;  
        public List<Subject> Subjects
        {
            get { return subjects; }
            set { subjects = value; }
        }
    }
    
    // I do not get what do you mean by course "section", very general.
    // used Subject instead, Change as you want just to give an idea
    public class Subject
    {
        string name;    
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        int creditHours;    
        public int CreditHours
        {
            get { return creditHours; }
            set { creditHours = value; }
        }
        public Subject(string _name, int _creditHours)
        {
            name = _name;
            creditHours = _creditHours;
        }
    }
    public class TestClass
    {
        public void DoSomething()
        {  
            // Subjects
            Subject subj1 = new Subject("C#", 10);
            Subject subj2 = new Subject(".Net", 10);
    
            // List of Subjects
            List<Subject> advancedPrSubjects = new List<Subject>();
            advancedPrSubjects.Add(subj1);
            advancedPrSubjects.Add(subj2);
    
            // Course
            Course advancedProgramming = new Course(advancedPrSubjects);            
           
    
            // Deliver authoroty to add Course to Department Class itself
            Department dept = new Department();
            dept.AddCourseToCourses(advancedProgramming);
        }
    }
