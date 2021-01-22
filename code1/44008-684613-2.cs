    public class Manager : Person
    {
        private string department;
    
        public Manager() { }
        public Manager(Employee newManager) : this()
        {
            base.Assign(newManager);
        }
    
        public string Department
        {
            get { return department; }
            set { department = value; }
        }
    
        protected new void Assign(Manager otherManager)
        {
            base.Assign(otherManager);
    
            Department = otherManager.Department;
        }
    }
