    LinqDBDataContext Context = new LinqDBDataContext();
    
       var query = from emps in
    
                      (
                           from empls in Context.Employees
                           where (empls.City == "London" || empls.City == "Seattle")
                            && empls.Region != null
                                 select new
                                  {
                                     FirstName = empls.FirstName,
                                     LastName = empls.LastName,
                                     City = empls.City,
                                     Region = empls.Region
                                  }
                       )
                  select emps;
    
    
                GridView1.DataSource = query;
                GridView1.DataBind();
