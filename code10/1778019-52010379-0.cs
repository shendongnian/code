    public interface IPhrase<T>
    {
        string Text { get; set; }
    }
    public class Phrase<T> : IPhrase<T> where T : Language
    {
        public string Text { get; set; }
        public DbSet<T> DbSet { get; set; }
        public Phrase(string text, DbContext context)
        {
            Text = text;
            DbSet = context.Set<T>();
        }
    }
    
    public class Language
    {
        //do smth
    }
    public class English : Language
    {
        //do smth
    }
    public class Spanish : Language
    {
        //do smth
    }
