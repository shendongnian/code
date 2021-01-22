    public class Student
    {
        private string _name;
        private int _id;
        private int _mark;
        private char _letterGrade;
        private Student()  // hide default Constructor
        { }
        public Student(string name, int id, int mark, char letterGrade) // Constructor
        {
            if( string.IsNullOrEmpty(name) )
                throw new ArgumentNullException("name");
            if( id <= 0 )
                throw new ArgumentOutOfRangeException("id");
            _name = name;
            _id = id;
            _mark = mark;
            _letterGrade = letterGrade;
        }
        // read-only properties - compressed to 1 line for SO answer.
        public string Name { get { return _name; } }
        public int Id { get { return _id; } }
        public int Mark { get { return _mark; } }
        public char LetterGrade { get { return _letterGrade; } }
    }
