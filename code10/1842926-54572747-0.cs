    public class CommonWatchableVariableContainer<T> where T : IComparable
    {
        private List<WatchableVariable<T>> Watchables;
        public void Add(string name)
        {
            var test = new WatchableVariable<T>(name);
            Watchables.Add(test);
        }
    }
