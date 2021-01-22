    internal class EmployeeWrapper
    {
        RealEmployeeFactory EmployeeFactory {get; set;}
        
        public virtual RealEmployee GetEligibleEmp(int id)
        {
            return EmployeeFactory.GetEligibleEmp(id);
        }
    } 
