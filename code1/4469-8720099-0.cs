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
            Random rand = new Random();
            if (!a_source.Any())
                return default(TItem);
            double dTotalWeight = a_source.Sum(i => i.Weight);
            while (true)
            {
                double dRandom = rand.NextDouble() * dTotalWeight;
                foreach (var item in a_source)
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
