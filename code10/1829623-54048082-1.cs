    public class Employee
    {
        private string Name;
        private int Income;
        public string FullName
        {
            set { Name = value;}
            get { return Name; }
        }
    
        public int Salary
        {
            set { Income = value; }
            get { return Income; }
        }
        public override string ToString()
        {
            return string.Format("Name: {0}, Salary: {1}", Name, Salary);
        }
    }
