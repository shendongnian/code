    class Employee
    {
        public int Id { get; private set; }
        public int? BossId { get; private set; }
        public string Name { get; private set; }
        public Employee(int id, int? bossId, string name)
        {
            Id = id;
            BossId = bossId;
            Name = name;
        }
    }
