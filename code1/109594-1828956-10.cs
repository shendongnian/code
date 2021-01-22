        public class FishingHook
        {
            public int Index { get; set; }
            public decimal RunningTotal { get; set; }
            public Func<decimal, bool> Criteria { get; set; }
        }
        public static IEnumerable<decimal> FishingHookIteration(IEnumerable<decimal> list, FishingHook hook)
        {
            hook.Index = 0;
            hook.RunningTotal = 0;
            foreach(decimal value in list)
            {
                // the hook object may define a Criteria delegate that
                // determines whether to skip the current value
                if (hook.Criteria == null || hook.Criteria(value))
                {
                    hook.RunningTotal += value;
                    yield return value;
                    hook.Index++;
                }
            }
        }
