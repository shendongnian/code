    using (IDbSchool dbSchool = SchoolFactory.CreateSchoolContext(...))
    {
          var teachersWithStudents = dbSchoolTeachers
              .Select(teacher => new
              {
                  Id = teacher.Id,
                  Name = teacher.Name,
                  Students = teacher.Students.Select(student => new
                  {
                      Id = student.Id,
                      Name = student.Name,
                  })
                  .ToList(),
              })
              .Where(teacher => teacher.Students.Any());
    }
