    var persons = (from r in distinct
                   select new PersonInfo
                   {
                       EmpId = (string)r["colA"],
                       FirstName = (string)r["colB"],
                       LastName = (string)r["colC"],
                   }).ToList();
    ...
    public class PersonInfo
    {
        public string EmpId {get;set;}
        public string FirstName {get;set;}
        public string LastName {get;set;}
    }
