        List<SourceData> source = new List<SourceData>();
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
                                  grp.Select(x => new Students
                                  {
                                      Student_Age = x.Student_Age,
                                      Student_Name = x.Student_Name
                                  }))
                          }).ToList();
