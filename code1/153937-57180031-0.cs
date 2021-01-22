        public static TSource MaxValue<TSource, TConversionResult>(this IEnumerable<TSource> source, Func<TSource, TConversionResult> function, IComparer<TConversionResult> comparer = null)
        {
            comparer = comparer ?? Comparer<TConversionResult>.Default;
            if (source == null) throw new ArgumentNullException(nameof(source));
            TSource max = default;
            TConversionResult maxFx = default;
            if ( (object)maxFx == null) //nullable stuff
            {
                foreach (var x in source)
                {
                    var fx = function(x);
                    if (fx == null || (maxFx != null && comparer.Compare(fx, maxFx) <= 0)) continue;
                    maxFx = fx;
                    max = x;
                }
                return max;
            }
            //valuetypes
            var notFirst = false;
            foreach (var x in source) 
            {
                var fx = function(x);
                if (notFirst)
                {
                    if (comparer.Compare(fx, maxFx) <= 0) continue;
                    maxFx = fx;
                    max = x;
                }
                else
                {
                    maxFx = fx;
                    max = x;
                    notFirst = true;
                }
            }
            if (notFirst)
                return max;
            throw new InvalidOperationException("Sequence contains no elements");
        }
