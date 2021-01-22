    public interface IAssignmentTimeEvent<out T> where T : ITimeEvent
    {
        T ParentTimeEvent
        {
            get;
        }
    }
