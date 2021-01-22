        public static IObservable<T> SampleResponsive<T>(
            this IObservable<T> source, TimeSpan delay)
        {
            return source.Publish(src =>
            {
                var fire = new Subject<T>();
                var whenCanFire = fire
                    .Select(u => new Unit())
                    .Delay(delay)
                    .StartWith(new Unit());
                src
                    .CombineVeryLatest(whenCanFire, (x, flag) => x)
                    .Subscribe(fire);
                return fire.Finally(subscription.Dispose);
            });
        }
        public static IObservable<TResult> CombineVeryLatest
            <TLeft, TRight, TResult>(this IObservable<TLeft> leftSource,
            IObservable<TRight> rightSource, Func<TLeft, TRight, TResult> selector)
        {
            var ls = leftSource.Select(x => new Used<TLeft>(x));
            var rs = rightSource.Select(x => new Used<TRight>(x));
            var cmb = ls.CombineLatest(rs, (x, y) => new { x, y });
            var fltCmb = cmb
                .Where(a => !(a.x.IsUsed || a.y.IsUsed))
                .Do(a => { a.x.IsUsed = true; a.y.IsUsed = true; });
            return fltCmb.Select(a => selector(a.x.Value, a.y.Value));
        }
        private class Used<T>
        {
            internal T Value { get; private set; }
            internal bool IsUsed { get; set; }
            internal Used(T value)
            {
                Value = value;
            }
        }
