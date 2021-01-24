     class Program
    {
        static ChallengeContext Context = null;
        static void Main(string[] args)
        {
            var test = GetChallenges();
        }
        public static IQueryable<Challenge> GetChallenges()
        {
            Context = new ChallengeContext();
            DbSet<Challenge> challenges = Context.Challenges;
            DbSet<ChallengeCategory> categories = Context.Categories;
           return challenges.Join(
                categories,
                ch => ch.Category,
                cc => cc.Id,
                (ch, cc) => new Challenge()
                {
                    Id = ch.Id
                });
        }
    }
    internal class ChallengeContext:DbContext
    {
        public DbSet<Challenge> Challenges { get; set; }
        public DbSet<ChallengeCategory> Categories { get; set; }
    }
    internal class ChallengeCategory
    {
        public int Id { get; set; }
    }
    public class Challenge
    {
        public int Id { get; set; }
        public int Category { get; set; }
    }
