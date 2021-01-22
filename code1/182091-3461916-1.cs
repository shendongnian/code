    public interface IPoll
    {
        bool Completed {get; set;}
        bool? Reopen { get; set; }
    }
    // Actual implementations are in the generated classes;
    // no need to provide any actual code. We're just telling the compiler
    // that we happen to have noticed the two classes implement the interface
    public partial class DirectorPoll : IPoll {}
    public partial class StudentPoll : IPoll {}
    // Any common behaviour can go in here.
    public static class PollExtensions
    {
        public static bool CanEdit(this IPoll poll)
        {
            return !poll.Completed || poll.Reopen.GetValueOrDefault(false);
        }
    }
