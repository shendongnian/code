    public interface  IListener
    {
        void Handle<TEventArgs>(TEventArgs e);
    }
    
    public class EventAggregator
    {
        static EventAggregator _TheEventAggregator;
        readonly Dictionary<Type, List<IListener>> _listeners;
        private EventAggregator()
        {
            _listeners = new Dictionary<Type, List<IListener>>();
        }
        public static EventAggregator GetTheEventAggregator()
        {
            if(_TheEventAggregator == null)
            {
                _TheEventAggregator = new EventAggregator();
            }
            return _TheEventAggregator;
        }
        public void Publish<TEventArgs>(object sender, TEventArgs e)
        {
            if(_listeners.ContainsKey(e.GetType()))
            {
                var listOfSubscribers = _listeners[e.GetType()];
                for(int i = listOfSubscribers.Count - 1; i > -1; i--)
                {
                    listOfSubscribers[i].Handle(e);
                }
            }
        }
        public void Subscribe<TEventArgs>(IListener listener)
        {
            if(_listeners.ContainsKey(typeof(TEventArgs)))
            {
                _listeners[typeof(TEventArgs)].Add(listener);
            }
            else
            {
                List<IListener> newListenerList = new List<IListener>();
                newListenerList.Add(listener);
                _listeners.Add(typeof(TEventArgs), newListenerList);
            }
        }
        //Cancels all subscriptions
        public void CancelSubscription<TEventArgs>(IListener listener)
        {
            Type eventArgsType = typeof(TEventArgs);
            if (_listeners.ContainsKey(eventArgsType))
            {
                //Remove from the end
                for (int i = _listeners[eventArgsType].Count-1; i > -1; i-- )
                {
                    //If the objects are the same 
                    if(ReferenceEquals(_listeners[eventArgsType][i], listener))
                    {
                        _listeners[eventArgsType].RemoveAt(i);
                    }
                }
            }
        }
    }
