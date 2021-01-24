    public class Player
    {
        public long Id { get; set; }
    
        // Foreign Key for "Teacher"
        public Guid? TeacherId { get; set; }
        // Foreign Key for "Student"
        public Guid? StudentId { get; set; }
    
        public Teacher Teacher { get; set; }
        public Student Student { get; set; }
    
        // Fields for Player no difference between teacher and student, JUST PLAYER
    }
    public class PlayerMap : EntityTypeConfiguration<Player>
    {
        public PlayerMap()
        {
            HasKey(x => x.Id);
            //...
    
            HasOptional(x => x.Teacher)
                .WithMany()
                .HasForeignKey(x => x.TeacherId);
            HasOptional(x => x.Student)
                .WithMany()
                .HasForeignKey(x => x.StudentId);
        }
    }
