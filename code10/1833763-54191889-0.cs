 cs
class Emp {
    public int EmployeeId {get;set;}
    public int MgrId {get;set;}
    public string EmpLastName {get;set;}
}
IEnumerable<Emp> EmployeeList = new List<Emp> {
    new Emp { EmployeeId = 1, MgrId = 0, EmpLastName = "boss" },
    new Emp { EmployeeId = 2, MgrId = 1, EmpLastName = "dude" } };
IDictionary<int, Emp> dict = EmployeeList.ToDictionary(e => e.EmployeeId);
var managers = EmployeeList
  .Select(e => dict.TryGetValue(e.MgrId, out Emp mgr) ? mgr : null)
  .OfType<Emp>()
  .ToList()
// List<Emp>(1) { Emp { EmpLastName="boss", EmployeeId=1, MgrId=0 } }
