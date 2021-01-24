    public class ShiftGroup
    {
        public int EmpId { get; set; }
        public int TotalHours { get; set; }
    }
    
    
    IQueryable<ShiftGroup> result =  context.shifts.Where(o => o.create_date == date).GroupBy(m => m.empId).select(
        g=>
        new ShiftGroup {
            EmpId = g.Key,
            TotalHours = g.Sum(s => s.hours) // need to calculate sum of hours worked in each employee
            }
    );
