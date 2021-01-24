    public class Employee
    {
        public string Name { get; set; }
        public string ID { get; set; }
        public Employee(string name, string id)
        {
            ID = id;
            Name = name;
        }
        public override bool Equals(object obj)
        {
            Employee item = obj as Employee;
            if (item == null)
            {
                return false;
            }
            return this.ID == item.ID && this.Name == item.Name;
        }
    }
