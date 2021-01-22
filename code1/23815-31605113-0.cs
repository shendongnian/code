    public partial static class IEnumerableExtensions
    {
        public static IEnumerable<Double> Derivate1<TSource>(this IEnumerable<TSource> source, Func<TSource, Double> selectorX, Func<TSource, Double> selectorY)
        {
            var enumerator = source.GetEnumerator();
            enumerator.Reset();
            enumerator.MoveNext();
            var itemPrevious = enumerator.Current;
            var itemNext = default(TSource);
            while (enumerator.MoveNext())
            {
                itemNext = enumerator.Current;
                var itemPreviousX = selectorX(itemPrevious);
                var itemPreviousY = selectorY(itemPrevious);
                var itemNextX = selectorX(itemNext);
                var itemNextY = selectorY(itemNext);
                var derivative = (itemNextY - itemPreviousY) / (itemNextX - itemPreviousX);
                yield return derivative;
                itemPrevious = itemNext;
            }
        }
    }
