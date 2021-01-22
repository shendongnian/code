    foreach (IGrouping<string, Student> groupedStudents in listOfStudents.GroupBy(g => g.Class))
                {
                    response.Add(groupedStudents.OrderByDescending(x => x.CreatedOn).Select(a =>
                    new ResponseClass
                    {
                        SName = a.StudentName,
                        SAge = a.Age,
                        SClass = a.Class,
                        SCreatedOn = a.CreatedOn,
                        RandomProperty = Guid.NewGuid().ToString()
                    }).First());
                }
