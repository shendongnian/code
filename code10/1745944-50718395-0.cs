    public class Student
    {
        public string v1 { get; set; }
        public int v2 { get; set; }
        public Student(string v1, int v2)
        {
            this.v1 = v1;
            this.v2 = v2;
        }
        public override string ToString()
        {
            return $"{{{v1}, {v2}}}";
        }
    }
