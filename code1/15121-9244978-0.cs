    public abstract class BaseBuilder<T, BLDR> where BLDR : BaseBuilder<T, BLDR>
                                               where T : new()
    {
        public abstract T Build();
        protected int Id { get; private set; }
        public BLDR WithId(int id)
        {
            _id = id;
            return (BLDR)this;
        }
    }
    public class ScheduleIntervalBuilder :
        BaseBuilder<ScheduleInterval,ScheduleIntervalBuilder>
    {
        private int _scheduleId;
        // ...
    
        public override ScheduleInterval Build()
        {
            return new ScheduleInterval
            {
                    Id = base.Id,
                    ScheduleId = _scheduleId
                        // ...
            };
        }
    
        public ScheduleIntervalBuilder WithScheduleId(int scheduleId)
        {
            _scheduleId = scheduleId;
            return this;
        }
    
        // ...
    }
