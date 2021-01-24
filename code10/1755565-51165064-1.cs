    public class StudentMap : EntityTypeConfiguration<Student>
        {
            public int MapID { get; set; }
            public string LastName { get; set; }
            public int Age { get; set; }
            public string Address { get; set; }
            public StudentMap()
            {
                // Table & parimary key Mappings
                this.ToTable("StudentMap");
                this.HasKey(t => t.ID);
            }
    
        }
