      public class TestBusFront : IBusFront
      {
        private readonly Dictionary<string, List<Delegate>> _list;
        public TestBusFront()
        {
            _list=new Dictionary<string, List<Delegate>>();
        }
        public void Publish(object o)
        {
            var d = GetDelegateListForEvent(o.GetType().FullName);
            foreach (var d1 in d)
            {
                var dynamicInvoke = d1.DynamicInvoke(o);
                var task = (Task) dynamicInvoke;
                task.Wait();
            }
        }
        public void SubscribeAsync<T>(string s, Func<T, Task> handle)
        {
            var delegates = GetDelegateListForEvent(typeof(T).FullName);
            delegates.Add(handle);
        }
        private List<Delegate> GetDelegateListForEvent(string eventName)
        {
            if(!_list.ContainsKey(eventName))
                _list.Add(eventName,new List<Delegate>());
            return _list[eventName];
        }
        public void Dispose()
        {
            
        }
    }
