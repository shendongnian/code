    public enum QuestionType
    {
        Scenario,
        Step
    }
    public class Question
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        [Required] [MaxLength(255)] public string Text { get; set; }
        [MaxLength(255)] public string FrameText { get; set; }
        public int Order { get; set; }
        public QuestionType Type { get; set; }
        public int? DefaultAnswerId { get; set; }
        [ForeignKey("Id,DefaultAnswerId")]
        public Answer DefaultAnswer { get; set; }
        public IList<Answer> Answers { get; set; }
    }
    public class Answer
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        [Required] [MaxLength(255)] public string Text { get; set; }
        public int Order { get; set; }
        public virtual Question Question { get; set; }
        //public Scenario Scenario { get; set; }
        //public IList<Formula> Formulas { get; set; }
        //public IList<Image> Images { get; set; }
    }
    class Db: DbContext
    {
        public DbSet<Question> Question { get; set; }
        public DbSet<Answer> Answer { get; set; }
        
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Answer>().HasKey(m => new { m.QuestionId, m.Id });
            modelBuilder.Entity<Answer>().HasRequired(m => m.Question).WithMany(q => q.Answers).HasForeignKey( m => m.QuestionId);
            modelBuilder.Entity<Question>().HasOptional(m => m.DefaultAnswer);
            
        }
    }
