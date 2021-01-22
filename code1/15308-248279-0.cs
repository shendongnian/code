    public class Student
    {
        protected string Name;
        protected int ID;
        protected int Mark;
        protected char Grade;
        public Student()  // default Constructor
        {
            Name = "";
            ID = 0;
            Mark = 0;
            Grade = '';
        }
        public Student(string Name, int ID, int Mark, char Grade) // Constructor
        {
            this.Name = Name;
            this.ID = ID;
            this.Mark = Mark;
            this.Grade = Grade;
        }
    }
