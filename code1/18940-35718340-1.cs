    // A simple example
    public class student
    {
        public int ID;
        public int passmark;
        public string name;
    }
    public class Program
    {
        public static void Main(string[] args)
        {
           student s1 = new student();
           s1.ID = -101; // here ID can't be -ve
           s1.Name = null ; // here Name can't be null
        }
    }
     
