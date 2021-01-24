    public sealed class MinimalEventSource : EventSource
    {
        public class Tasks
        {
            public const EventTask Information = (EventTask)1;
        }
    
        public static MinimalEventSource Log = new MinimalEventSource();
    
        [Event(1, Message = "{0}", Opcode = EventOpcode.Info, Task = Tasks.Information)]
        public void Information(string message)
        {
            if (IsEnabled())
            {
                WriteEvent(1, message);
            }
        }
    }
