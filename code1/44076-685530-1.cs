        List<SourceData> source = new List<SourceData>();
        //...your data here ;-p
        var classes = (from row in source
                      group row by new {
                              row.ID, row.Name,
                              row.Teacher, row.RoomName }
                          into grp
                          select new SchoolClass
                          {
                              ID = grp.Key.ID,
                              Name = grp.Key.Name,
                              Teacher = grp.Key.Teacher,
                              RoomName = grp.Key.RoomName,
                              Students = new List<Students>(
                                  from row in grp
                                  select new Students
                                  {
                                      Student_Age = row.Student_Age,
                                      Student_Name = row.Student_Name
                                  })
                          }).ToList();
