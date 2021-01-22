        public abstract class State
        {
            public Guid Id { get; set; }
            public string Description { get; set; }
            public abstract void DoSomething();
        }
        public class WorkingState : State
        {
            public override void DoSomething()
            {
                //Do something specific for the working state
            }
        }
        public class VacationState : State
        {
            public override void DoSomething()
            {
                //Do something specific for the vacation state
            } 
        }
        public class StateFactory
        {
            public static State CreateState(IDataRecord record)
            {
                if (record.GetBoolean(2))
                    return new WorkingState { Id = record.GetGuid(0), Description = record.GetString(1) };
                if (record.GetBoolean(3))
                    return new VacationState { Id = record.GetGuid(0), Description = record.GetString(1) };
                throw new Exception("Data is screwed");
            }
        }
