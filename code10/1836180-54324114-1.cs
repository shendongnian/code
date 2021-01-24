    public class Employee: IEmployee
    {
        private ISalary _salary;
        public void SetSalary(ISalary salary)
        {
            this._salary = salary;
        }
    }
