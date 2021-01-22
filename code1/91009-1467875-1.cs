    public class FuncList
    {
        private readonly List<Delegate> list = new List<Delegate>();
        public void Add<T>(Func<T> func)
        {
            list.Add(func);
        }
    }
