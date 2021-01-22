        public class Something
        {
            public decimal Amount { get; set; }
            public decimal OtherAmount { get; set; }
        }
        public static void UpdateAmounts<T, U>(IEnumerable<T> items, Action<T,U> setter, Func<T, U> getter)
        {
            foreach (var o in items)
            {
                setter(o, getter(o));
            }
        }
        public void QuickTest()
        {
            var s = new [] { new Something() { Amount = 1, OtherAmount = 11 }, new Something() { Amount = 2, OtherAmount = 22 }};
            UpdateAmounts(s, (o,v) => o.Amount = v, (o) => o.Amount + 1);
            UpdateAmounts(s, (o,v) => o.OtherAmount = v, (o) => o.OtherAmount + 2);
        }
