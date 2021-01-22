                        //Json Formating code
                        //DT is DataTable
                        var filter = (from r1 in DT.AsEnumerable()
                                      //Grouping by multiple columns 
                                      group r1 by new
                                      {
                                          EMPID = r1.Field<string>("EMPID"),
                                          EMPNAME = r1.Field<string>("EMPNAME"),
                                      } into g
                                      //Selecting as new type
                                      select new
                                      {
                                          EMPID = g.Key.EMPID,
                                          MiddleName = g.Key.EMPNAME});
                                                  
