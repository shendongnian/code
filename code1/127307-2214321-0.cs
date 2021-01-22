    class Employee {
      public Employee(string name, string address, int salary) {
        Name = name; Address = address; this.salary = salary;
      }
      private int salary;
      public event Action<Employee> SalaryChanged;
      public string Name { get; set; }
      public string Address { get; set; }
      public int Salary {
        get { return salary; }
        set { 
          salary = value;  
          if (SalaryChanged != null) SalaryChanged(this);
        }
      }
     
    var fred = new Employee(...);
    fred.SalaryChanged += (changed_employee) => 
      Console.WriteLine("Send {0} a new tax bill!", changed_employee.Name);
     
