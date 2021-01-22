    public class CalculateDowntimeTask : Task<CalculateDowntimeTask>
    {
        public CalculateDowntimeTask(object proxy, object context) : 
            base((TaskServiceClient)proxy, (TaskDataDataContext)context) { }
        public override void Execute()
        {
            LogMessage(new TaskMessage() { Message = "Testing" });
            BroadcastMessage(new TaskMessage() { Message = "Testing" });
        }
    }
