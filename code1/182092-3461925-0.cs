    partial class DirectorPoll : IGenericPoll {}
    partial class StudentPoll : IGenericPoll {}
    public interface IGenericPoll
    {
        bool Completed { get; set; }
        bool? Reopen { get; set; }
    }
    public static class GenericPoll {
        public static bool CanEdit(this IGenericPoll instance)
        {
            return !instance.Completed || instance.Reopen.GetValueOrDefault();
        }
    }
