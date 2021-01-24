        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeSkills>(e =>
            {
                e.HasKey(l => new { l.SkillsId, l.EmployeeId });
            });
            modelBuilder.Entity<Skills>(e =>
            {
                e.HasData(new[]
                {
                    new Skills() { Id = 1, Skill="JAVA" },
                    new Skills() { Id = 2, Skill="DOTNET" },
                    new Skills() { Id = 2, Skill="PYTHON" },
                });
            });
            base.OnModelCreating(modelBuilder);
        }
