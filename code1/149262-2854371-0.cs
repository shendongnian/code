    public static double Score<T>(T item, IEnumerable<Weighting<T>> weights)
    {
        return weights.Aggregate(0.0, (p, w) => p + w.Apply(item));
    }
    public static T MaxBy<T>(this IEnumerable<T> items, Func<T, double> selector)
    {
        double curMax = double.MinValue;
        T curItem = default(T);
        foreach (T i in items)
        {
            double curValue = selector(i);
            if (curValue > curMax) 
            {
                curMax = curValue;
                curItem = i;
            }
        }
        return curItem;
    }
    public class Weighting<T>
    {
        public Weighting(double weight, Func<T, double> attributeSelector)
        {
            _weight = weight;
            _attributeSelector = attributeSelector;
        }
        private readonly double _weight;
        private readonly Func<T, double> _attributeSelector;
        public double Apply(T item) { return _weight * _attributeSelector(item); }
    }
    Weighting<Item>[] weights = {new Weighting<Item>(1, i => i.Elasticity),
                                 new Weighting<Item>(2, i => i.Firmness),
                                 new Weighting<Item>(.5, i => i.Strength)};
    var hsQuery = from i in allItems
                  group i by i.Box into boxItems
                  select boxItems.MaxBy(bi => Score(bi, weights));
