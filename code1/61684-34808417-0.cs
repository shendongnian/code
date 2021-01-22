    public class Context<T>
    {
        private Dictionary<int, T> dictContext;
        public String Name { get; private set; }
        public Context (String name)
        {
            this.Name = name;
            dictContext = new Dictionary<int, T>();
        }
