    public static IEnumerable<Data> FillIn(this IEnumerable<Data> original)
    {
        Data lastItem = null;
        foreach (var item in original)
        {
            if (lastItem != null)
            {
                var fakeItem = new DateTime(lastItem.TransactionDate.Year,
                    lastItem.TransactionDate.Month, lastItem.TransactionDate.Day)
                    .AddDays(1);
                while (fakeItem.TransactionDate != item.TransactionDate)
                {
                    yield return fakeItem;
                    fakeItem.TransactionDate = fakeItem.TransactionDate.AddDays(1);
                }
            }
            lastItem = item;
            yield return item;
        }
    }
