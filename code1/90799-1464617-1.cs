    class Program
    {
        class Employee
        {
            int _id;
            string _firstName;
            string _lastName;
            int _salary;
            public Employee(int id, string firstName, string lastName, int salary)
            {
                this._id = id;
                this._firstName = firstName;
                this._lastName = lastName;
                this._salary = salary;
            }
            public int Id { get { return _id; } }
            public string FirstName { get { return _firstName; } }
            public string LastName { get { return _lastName; } }
            public int Salary { get { return _salary; } }
        }
    
        static void Main()
        {
            Employee[] employees = new Employee[4];
            employees[0] = new Employee(1, "David", "Smith", 10000);
            employees[1] = new Employee(3, "Mark", "Drinkwater", 30000);
            employees[2] = new Employee(4, "Norah", "Miller", 20000);
            employees[3] = new Employee(12, "Cecil", "Walker", 120000);
    
            using (XmlWriter writer = XmlWriter.Create("employees.xml"))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("Employees");
    
                foreach (Employee employee in employees)
                {
                    writer.WriteStartElement("Employee");
    
                    writer.WriteElementString("ID", employee.Id.ToString());
                    writer.WriteElementString("FirstName", employee.FirstName);
                    writer.WriteElementString("LastName", employee.LastName);
                    writer.WriteElementString("Salary", employee.Salary.ToString());
    
                    writer.WriteEndElement();
                }
    
                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }
    }
