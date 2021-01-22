    // using HQL
    var students = Session.CreateQuery("from Students s where s.Grades = :grade")
                     .SetParameter("grade","A")
                     .List<Student>();
    
    // using NHibernate.Linq
    var students = Session.Linq<Student>().Where(s => s.Grades == "A").ToList();
    // or something more complex
    var students = Session.Linq<Student>()
                     .Where(s => s.Grades.Where(x => x.Score == "A"))
                     .ToList();
