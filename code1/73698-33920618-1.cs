        public class CachedCalculator
        {
            private Func<int, int> _heavyExpensiveMultiplier;
            public Calculator(Func<int,int> heavyExpensiveMultiplier )
            {
                //wrap function into cached one
                this._heavyExpensiveMultiplier 
                  = heavyExpensiveMultiplier.Cached(x =>/*key for cache*/ x.ToString(), TimeSpan.FromSeconds(42));
            }
            //this uses cached algorithm
            public int Compute(int x)
            {
                return _heavyExpensiveMultiplier(x);
            }
        }
    
