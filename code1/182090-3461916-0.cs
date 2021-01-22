    public interface IPoll
    {
        bool Completed {get; set;}
        bool? Reopen { get; set; }
    }
    // Actual implementations are in the generated classes
    public partial class DirectorPoll : IPoll {}
    public partial class StudentPoll : IPoll {}
    public static class PollExtensions
    {
        public static bool CanEdit(this IPoll poll)
        {
            return poll.!Completed || poll.Reopen.GetValueOrDefault(false);
        }
    }
