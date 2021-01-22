    class Employee
    {
        public int Id { get; private set; }
        public int? BossId { get; private set; }
        public List<Employee> Underlings { get; set; }
        public Employee(int id, int? bossId)
        {
            Id = id;
            BossId = bossId;
        }
    }
