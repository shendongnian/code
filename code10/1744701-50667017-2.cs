        public static IObservable<T> When<T>(this IObservable<T> source, IObservable<bool> gate)
        {
            return gate
                .Select(g => g ? source : source.IgnoreElements())
                .Switch()
                .TakeUntil(source.Materialize()
                                 .Where(s => s.Kind == NotificationKind.OnCompleted));
        }
