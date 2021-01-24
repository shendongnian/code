     public static IObservable<Unit> TripleClick(this ButtonBase element, int totalMillisecondsLimit = 1000)
        {
            return element.Events().Click // get clicks
                 .Select(x => Unit.Default).TimeInterval().Select(x => x.Interval) // get time intervals between them
                 .Window(3) // always look at last 3
                 .SelectMany(x => x.ToArray()) // just make array from observable produced by Window
                 .Where(x => x.Skip(1).Sum(z => z.TotalMilliseconds) < totalMillisecondsLimit) // check if the 3 clicks are very close to each other
                 .Select(x => Unit.Default); // you can return whatever you want, Unit.Default is Reactive version of void
        }
