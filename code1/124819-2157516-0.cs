    public class StudentGrouping {
        public string Name { get; set; }
        public int Quantity { get; set; }
    }
    public IQueryable<StudentGrouping> FindStudentsDistinctWithQuantity()
    {
        /*SELECT Name, COUNT(Name) AS Quantity
        FROM Student
        GROUP BY Name*/
        var students= (from s in db.Students
                    group s by s.Name into g
                    select new StudentGrouping {
                       Name = g.Key, 
                       Quantity = g.Count()
                    }).AsQueryable();            
        return students;
    }
