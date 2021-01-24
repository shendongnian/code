    public class PredicateCollection<T> : List<IPredicate<T>>, IPredicate<T>
    {
        public bool Condition(T t)
        {
            return this.All(x => x.Condition(t));
        }
    }
