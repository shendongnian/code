    //students are people with a grade and a teacher
    public class Student : Person
    {
        public Student(string _name, int _grade, 
            Teacher _teacher) : base(_name)
        {
            Grade = _grade;
            Teacher = _teacher;
            Teacher.Students.Add(this);  //add to the teacher's collection
        }
        public int Grade;
        public Teacher Teacher;
    }
