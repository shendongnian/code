    public string GetName(EmployeeWrapper employee, int id)
    {
         var eligibileEmp = employee.GetEligibleEmp(id); <---------you can stub this
         if(eligibleEmp.Equals(empValue)
         {
          ..........
         }
    }
