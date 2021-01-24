    class Wrapper
    {
        public Subject Subject { get; set; }
        public Curriculum Curriculum { get; set; }
    }
    List<Wrapper> YourMethodName(...)
    {
        ...
            {
                var v = (from a in dc.Subjects
                         from b
                         in dc.Curricula
                              .Where(o => a.SubjectCode == o.CourseCode)
                              .DefaultIfEmpty()
                         where
                                a.SubjectCode.Contains(search) ||
                                a.SubjectName.Contains(search) ||
                                a.Curriculum.DescriptiveTitle.Contains(search) ||
                                a.Schedule.Contains(search) ||
                                a.Instructor.Contains(search) ||
                                a.Room.Contains(search)
                         select new Wrapper { Subject = a, Curriculum = b});
    
                totalRecord = v.Count();
                v = v.OrderBy(x => x.Curriculum.Year).ThenBy(x => x.Curriculum.Sem);
                return v.ToList();
    }
