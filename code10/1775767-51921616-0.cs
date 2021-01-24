    public class Mediator
    {
        static readonly Mediator instance = new Mediator();
        public static Mediator Instance
        {
            get
            {
                return instance;
            }
        }
        private Mediator()
        {
        }
        private static Dictionary<string, Action<object>> subscribers = new Dictionary<string, Action<object>>();
        public void Register(string message, Action<object> action)
        {
            subscribers.Add(message, action);
        }
        public void Notify(string message, Object param)
        {
            foreach (var item in subscribers)
            {
                if (item.Key.Equals(message))
                {
                    Action<object> method = (Action<object>)item.Value;
                    method.Invoke(param);
                }
            }
        }
    }
