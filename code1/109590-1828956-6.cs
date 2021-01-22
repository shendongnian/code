        public class FishingHook
        {
            public int Index;
            public decimal RunningTotal;
        }
        public static IEnumerable<decimal> FishingHookIteration(IEnumerable<decimal> list, FishingHook hook)
        {
            hook.Index = 0;
            hook.RunningTotal = 0;
            foreach(decimal value in list)
            {
                hook.RunningTotal += value;
                yield return value;
                hook.Index++;
            }
        }
