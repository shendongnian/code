    public class SampleQuestion
    {
        public int SampleQuestionId { get; set; }
        public string Question { get; set; }
        public List<SampleQuestionAnswer> Answers { get; set; }
    }
    public class SampleQuestionAnswer
    {
        public int SampleQuestionAnswerId { get; set; }
        public string Value { get; set; }
    }
    // Type configuration for SampleQuestion entity
    public class SampleQuestionConfiguration : EntityTypeConfiguration<SampleQuestion>
    {
        public override void Configure(EntityTypeBuilder<SampleQuestion> builder)
        {
            builder.ToTable("SampleQuestion");
            builder.Property(q => q.SampleQuestionId).UseSqlServerIdentityColumn();
            builder.HasMany(q => q.Answers); // Check that answers has links to questions in database
        }
    }
    // Type configuration for SampleQuestionAnswer entity
    public class SampleQuestionAnswerConfiguration : EntityTypeConfiguration<SampleQuestionAnswer>
    {
        public override void Configure(EntityTypeBuilder<SampleQuestionAnswer> builder)
        {
            builder.ToTable("SampleQuestionAnswer");
            builder.Property(b => b.SampleQuestionAnswerId).UseSqlServerIdentityColumn();
        }
    }
    // Create special context
    public class QuestionDbContext : DbContext
    {
        public DbSet<SampleQuestion> SampleQuestions { get; set; }
        public DbSet<SampleQuestionAnswer> SampleQuestionsAnswers { get; set; }
        public QuestionDbContext(DbContextOptions options)
             : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfiguration(new SampleQuestionConfiguration())
                .ApplyConfiguration(new SampleQuestionAnswerConfiguration());
            SampleQuestions.Include(x => x.Answers);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            QuestionDbContext qContext = new QuestionDbContext(new DbContextOptionsBuilder<QuestionDbContext>()
                .UseSqlServer("connectionString")
                .Options);
            var questions = qContext.SampleQuestions.AsNoTracking(); // not elegant, but it will work
        }
    }
