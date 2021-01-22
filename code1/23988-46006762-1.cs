     public class **JoinElement**
    {
        public int? Id { get; set; }
        public string Name { get; set; }
    }
    results = from course in courseQueryable.AsQueryable()
                      join agency in agencyQueryable.AsQueryable()
                       on new **JoinElement**() { Id = course.CourseAgencyId, Name = course.CourseDeveloper } 
                       equals new **JoinElement**() { Id = agency.CourseAgencyId, Name = "D" } into temp1
