    public class GroupSourceOfEvents : ISourceOfEvents
    {
        public IList<ISourceOfEvents> SourceOfEventsGroup { get; private set; }
        public event Action<EventInfo1> SomethingHappened1
        {
            add
            {
                foreach (var s in SourceOfEventsGroup)
                {
                    s.SomethingHappened1 += value;
                }
            }
            remove
            {
                foreach (var s in SourceOfEventsGroup)
                {
                    s.SomethingHappened1 -= value;
                }
            }
        }
        public event Action<EventInfo2> SomethingHappened2
        {
            add
            {
                foreach (var s in SourceOfEventsGroup)
                {
                    s.SomethingHappened2 += value;
                }
            }
            remove
            {
                foreach (var s in SourceOfEventsGroup)
                {
                    s.SomethingHappened2 -= value;
                }
            }
        }
        // {...}
        public GroupSourceOfEvents(IList<ISourceOfEvents> sourceOfEventsGroup)
        {
            SourceOfEventsGroup = sourceOfEventsGroup;
            foreach (var s in SourceOfEventsGroup)
            {
                // {...}
            }
        }
    }
