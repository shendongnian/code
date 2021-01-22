    public class AdvancedSwitch<T> where T : struct
    {
        protected Dictionary<T, Action> handlers = new Dictionary<T, Action>();
        public void AddHandler(T caseValue, Action action)
        {
            handlers.Add(caseValue, action);
        }
        public void RemoveHandler(T caseValue)
        {
            handlers.Remove(caseValue);
        }
        public void ExecuteHandler(T actualValue)
        {
            ExecuteHandler(actualValue, Enumerable.Empty<T>());
        }
        public void ExecuteHandler(T actualValue, IEnumerable<T> ensureExistence)
        {
            foreach (var val in ensureExistence)
                if (!handlers.ContainsKey(val))
                    throw new InvalidOperationException("The case " + val.ToString() + " is not handled.");
            handlers[actualValue]();
        }
    }
