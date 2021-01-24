    public class Course
    {
        public Course(int code, string name, string professor, int capacity)
        {
            Code = code;
            Name = name;
            Professor = professor;
            Capacity = capacity;
        }
    
        // properties should be in PascalCase
        // and should not have their entity's name as prefix 
        public int Code { get; set; }
        public string Name { get; set; }
        public string Professor { get; set; }
        public int Capacity { get; set; }
    }
