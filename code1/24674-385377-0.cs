    public class Student
    {
        // Notice how these details are private
        private List<Subjects> _subjects = new List<Subjects>();
        private DateTime _started;
        // A property that only has a 'getter' because the value shouldn't be modified
        public DateTime Started
        {
            get { return _started; }
        }
        // Methods carry out actions. This one calls on to a method in another object.
        public void Enroll(Subject s)
        {
            if (_subjects.Contains(s))
                throw new Exception("Already studying that course");
            s.RegisterStudent(this);
            _subjects.Add(s); 
        }
        public void Flunk(Subject s)
        {
            if (!_subjects.Contains(s))
                throw new Exception("Can't flunk that subject, not studying it");
            s.RemoveStudent(this);
            _subjects.Remove(s);
        }
    }
