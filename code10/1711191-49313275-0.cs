    public class Course
    {
        public string CourseCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int NoOfEvaluations { get; set; }
        public IEnumerable<Course> Courses { get; set; }
        public Course()
        {
            Courses = new List<Course>();
        }
        //this will format the text to your specification
        public string ToDelimitedString(char Delimiter)
        {
            return String.Format("{0}{4}{1}{4}{2}{4}{3}{5}"
                , this.CourseCode
                , this.Name
                , this.Description
                , this.NoOfEvaluations.ToString()
                , Delimiter
                , Environment.NewLine);
        }
        public void Export(string FileName, char Delimiter)
        {
            //this will be more efficient than writing on line at a time
            var coursesExport = new StringBuilder();
            
            foreach(var course in this.Courses)
            {
                coursesExport.Append(course.ToDelimitedString(Delimiter));
            }
            File.WriteAllText(FileName, coursesExport.ToString());
        }
    }
