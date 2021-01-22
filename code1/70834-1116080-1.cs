    internal sealed class TypeDispatchProcessor
    {
        private readonly Dictionary<Type, Action<object>> _actionByType 
            = new Dictionary<Type, Action<object>>();
    
        public void RegisterProcedure<T>(Action<T> action)
        {
            _actionByType[typeof(T)] = item => action((T) item);
        }
    
        public void ProcessItem(object item)
        {
            Action<object> action;
            if (_actionByType.TryGetValue(item.GetType(), out action))
            {
                action(item);
            }
        }
    }
