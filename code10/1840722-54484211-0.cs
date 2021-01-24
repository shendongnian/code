    public class StatesOverTime<T>
    {
        public IList<StateOverTime<T>> States = new List<StateOverTime<T>>();
        public TimeSpan TotalTimeWhere(Func<StateOverTime<T>, bool> predicate)
        {
            //var results = States.Where(function);
            var results = States.Where(predicate);
            var blah = new TimeSpan(results.Select(x => x.TimeSpan).Sum(x => x.Ticks));
            return blah;
        }
        public double PercentDownTime;
    }
