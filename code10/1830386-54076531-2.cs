    public class EmployeeModel
    {
        public EmployeeModel(string id, string employee_name,string employee_salary, string employee_age, string profile_image )
        {
            this.id = id;
            this.employee_name = employee_name;
            this.employee_salary = employee_salary;
            this.employee_age = employee_age;
            this.profile_image = profile_image;
        }
        public string id { get; private set; }
        public string employee_name { get; private set; }
        public string employee_salary { get; private set; }
        public string employee_age { get; private set; }
        public string profile_image { get; private set; }
    }
