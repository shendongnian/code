    [ActionName("_EmployeeDetailsByModel")]
            public PartialViewResult _EmployeeDetails(Employee model)
            {
                // Some Operation                
                    return PartialView(model);
                }
            }
    
    [ActionName("_EmployeeDetailsByModelWithPagination")]
            public PartialViewResult _EmployeeDetails(Employee model,int Page,int PageSize)
            {
               
                    // Some Operation
                    return PartialView(model);
               
            }
