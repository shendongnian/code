    interface IBonusTrait
    {
        decimal ApplyBonus(Employee employee, decimal currentTotal);
    }
    
    class Employee
    {
        // ...
    
        public decimal BaseSalary { get; set; }
        public IList<IBonusTrait> BonusTraits { get; set; }
    }
    
    class SalaryCalculator
    {
        public decimal CalculateSalary(Employee employee)
        {
            decimal totalSalary = employee.BaseSalary;
            foreach (IBonusTrait bonusTrait in employee.BonusTraits)
            {
                totalSalary = bonusTrait.ApplyBonus(employee, totalSalary);
            }
    
            return totalSalary;
        }
    }
