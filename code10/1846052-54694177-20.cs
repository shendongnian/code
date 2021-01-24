    public class Employee : IEmployee
    {
        private readonly INameRepo _repo;
        public Employee(INameRepo repo)
        {
             //this is dependancy injection
             _repo = repo;
        }
        public async Task<string> WriteNameToDataBase()
        {
            var employeeName = await _repo.GetName();
            return $"Wrote {employeeName.Result} to database";
        }
     }
