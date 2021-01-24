public abstract class EventData<T> where T : EventData<T>
    {
        Action<T> action_;
        public void Subscribe(Action<T> _actor) { action_ += _actor; }
        public void Unsubscribe(Action<T> _actor) { action_ -= _actor; }
        public void Dispatch(T _data) { if (action_ != null) action_(_data); }
    }
    public class EventBus
    {
        static Dictionary<string, EventData> _dict;
    }
(moreovere, i cannot do that and i could be forced to find a solution for that problem too)
I can simply use
public class EventBus<T> where T : EventArgs
    {
        static Dictionary<string, Action<T>> list;
        public static void SubscribeOnEvent(string _sid, Action<T> _method)
        {
            // Do Stuff...
        }
    }
And use it in the way like 
EventBus<MyData>.Subscibe("myID", (data) => { /*Do stuff...*/ });
And now i can use all the data, derived from `EventArgs`. Thanks to @JeroenMostert for the idea.
