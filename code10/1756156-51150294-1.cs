    var students = from s in db.Student
                   group s by s.name into groupedResult
                   select new 
                   {
                      Name = groupedResult.Key,
                      Max_Status = groupedResult.Max(g => g.Status)
                   } ;
