    class Program
    {
        static void Main(string[] args)
        {
            School school1 = new School("School Name", "School Address");
        }
    }
    public class School
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public School(string name, string address)
        {
            this.Name = name;
            this.Address = address;
        }
    }
