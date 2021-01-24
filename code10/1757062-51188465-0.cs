    int upper = int.MinValue;
    values = values
        .GroupBy(x => Math.Min(x.Item1, x.Item2))
        .OrderBy(x => x.Key)
        .Select(x => x.OrderBy(y => Math.Max(y.Item1, y.Item2)).Last())
        .Where(x =>
        {
            var max = Math.Max(x.Item1, x.Item2);
            if (upper < max)
            {
                upper = max;
                return true;
            }
            else
            {
                return false;
            }
        }).ToList();
