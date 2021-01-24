    public class Student : IComparable<Student>
    {
        public int ID {get;set;}
        public string Name {get;set;}
    
        public int CompareTo(Student other)
        {
            return string.Compare(Name, other.Name);
        }
    }
