    public class TSwitch<TResult>
    {
        class CaseInfo<T>
        {
            public Type Target { get; set; }
            public Func<object, T> Func { get; set; }
        }
        private object _source;
        private List<CaseInfo<TResult>> _cases;
        public static TSwitch<TResult> On(object source)
        {
            return new TSwitch<TResult> { 
                _source = source,
                _cases = new List<CaseInfo<TResult>>()
            };
        }
        public TResult Default(Func<object, TResult> defaultFunc)
        {
            var srcType = _source.GetType();
           foreach (var entry in _cases)
                if (entry.Target.IsAssignableFrom(srcType))
                    return entry.Func(_source);
            return defaultFunc(_source);
        }
        public TSwitch<TResult> Case<TSource>(Func<TSource, TResult> func)
        {
            _cases.Add(new CaseInfo<TResult>
            {
                Func = x => func((TSource)x),
                Target = typeof(TSource)
            });
            return this;
        }
    }
