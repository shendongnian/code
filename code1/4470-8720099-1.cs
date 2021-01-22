    public static class WeightedEx
    {
        /// <summary>
        /// Select an item from the given sequence according to their respective weights.
        /// </summary>
        /// <typeparam name="TItem">Type of item item in the given sequence.</typeparam>
        /// <param name="a_source">Given sequence of weighted items.</param>
        /// <returns>Randomly picked item.</returns>
        public static TItem PickWeighted<TItem>(this IEnumerable<TItem> a_source)
            where TItem : IWeighted
        {
            if (!a_source.Any())
                return default(TItem);
            var source= a_source.OrderBy(i => i.Weight);
            double dTotalWeight = source.Sum(i => i.Weight);
            Random rand = new Random();
            while (true)
            {
                double dRandom = rand.NextDouble() * dTotalWeight;
                foreach (var item in source)
                {
                    if (dRandom < item.Weight)
                        return item;
                    dRandom -= item.Weight;
                }
            }
        }
    }
    /// <summary>
    /// IWeighted: Implementation of an item that is weighted.
    /// </summary>
    public interface IWeighted
    {
        double Weight { get; }
    }
