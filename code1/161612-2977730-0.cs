    // usage...
    var lst = new List<IAssignmentTimeEvent>();
    // new interface
    public interface IAssignmentTimeEvent
    {
        ITimeEvent ParentTimeEvent { get; set; }
    }
    public interface IAssignmentTimeEvent<T> : IAssignmentTimeEvent
        where T : ITimeEvent
    {
        new T ParentTimeEvent { get; set; }
    }
    public class ScheduleJobTimeEvent : 
        IAssignmentTimeEvent<IJobTimeEvent>
    {
        public IJobTimeEvent ParentTimeEvent { get; set; }
        ITimeEvent IAssignmentTimeEvent.ParentTimeEvent
        {
            get { return ParentTimeEvent; }
            set
            {
                if (!(value is IJobTimeEvent))
                    throw new InvalidCastException();
                ParentTimeEvent = value as IJobTimeEvent;
            }
        }
    }
    public class ScheduleActivityTimeEvent : 
        IAssignmentTimeEvent<IActivityTimeEvent>
    {
        public IActivityTimeEvent ParentTimeEvent { get; set; }
        ITimeEvent IAssignmentTimeEvent.ParentTimeEvent
        {
            get { return ParentTimeEvent; }
            set
            {
                if (!(value is IActivityTimeEvent))
                    throw new InvalidCastException();
                ParentTimeEvent = value as IActivityTimeEvent;
            }
        }
    }
