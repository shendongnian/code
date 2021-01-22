    public static partial class MathHelpers
    {
        public static Double Derivate(Double xPrevious, Double xNext, Double yPrevious, Double yNext)
        {
            var derivative = (yNext - yPrevious)/(xNext - xPrevious);
            return derivative;
        }
    }
    public static class IEnumerableExtensions
    {
         public static IEnumerable<Double> Derivate<TSource>(IEnumerable<TSource> source, Func<TSource, Double> selectorX, Func<TSource, Double> selectorY)
         {
             var itemPrevious = source.First();
             source = source.Skip(1);
             foreach (var itemNext in source)
             {
                 var derivative = MathHelpers.Derivate(selectorX(itemPrevious), selectorX(itemNext), selectorY(itemPrevious), selectorY(itemNext));
                 yield return derivative;
                 itemPrevious = itemNext;
            }
        }
    }
