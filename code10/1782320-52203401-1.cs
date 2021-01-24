    var Leaves = DbEntities.Usp_EmployeeWebLeave(EmployeeId)
                                 .FirstOrDefault();
    EmployeeLeaves mEmployeeLeaves=Converter(Leaves)
   
 
    
 
    EmployeeLeaves Converter(usp_EmployeeWebLeave_Result e)
    {
       return new
                 HumanResource.Paycare.EmployeeLeaves(){
                       Name=leaves.Name,
                       Age=leaves.Age
                       ...........
              }   ;
    } 
