    public class GroupSourceOfEvents : ISourceOfEvents
    {
        private object SourceOfEventsGroupLock = new object();
        private IList<ISourceOfEvents> _SourceOfEventsGroup;
        public IEnumerable<ISourceOfEvents> SourceOfEventsGroup
        {
            get { return _SourceOfEventsGroup; }
        }
        public void AddSource(ISourceOfEvents source)
        {
            lock (SourceOfEventsGroupLock)
            {
                source.SomethingHappened1 += _SomethingHappened1;
                source.SomethingHappened2 += _SomethingHappened2;
                _SourceOfEventsGroup.Add(source);
            }
        }
        public void RemoveSource(ISourceOfEvents source)
        {
            lock (SourceOfEventsGroupLock)
            {
                source.SomethingHappened1 -= _SomethingHappened1;
                source.SomethingHappened2 -= _SomethingHappened2;
                _SourceOfEventsGroup.Remove(source);
            }
        }
        private Action<EventInfo1> _SomethingHappened1;
        public event Action<EventInfo1> SomethingHappened1
        {
            add
            {
                lock (SourceOfEventsGroupLock)
                {
                    _SomethingHappened1 += value;
                    foreach (var s in SourceOfEventsGroup)
                    {
                        s.SomethingHappened1 += value;
                    }
                }
            }
            remove
            {
                lock (SourceOfEventsGroupLock)
                {
                    _SomethingHappened1 -= value;
                    foreach (var s in SourceOfEventsGroup)
                    {
                        s.SomethingHappened1 -= value;
                    }
                }
            }
        }
        private Action<EventInfo2> _SomethingHappened2;
        public event Action<EventInfo2> SomethingHappened2
        {
            add
            {
                lock (SourceOfEventsGroupLock)
                {
                    _SomethingHappened2 += value;
                    foreach (var s in SourceOfEventsGroup)
                    {
                        s.SomethingHappened2 += value;
                    }
                }
            }
            remove
            {
                lock (SourceOfEventsGroupLock)
                {
                    _SomethingHappened2 -= value;
                    foreach (var s in SourceOfEventsGroup)
                    {
                        s.SomethingHappened2 -= value;
                    }
                }
            }
        }
        // {...}
        public GroupSourceOfEvents(IList<ISourceOfEvents> sourceOfEventsGroup)
        {
            _SourceOfEventsGroup = sourceOfEventsGroup;
        }
    }
