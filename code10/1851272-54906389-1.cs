    void CreateZeroSumCollections<TSource>(IEnumerable<TSource> source,
         Func<TSource, int> keySelector,
         out IList<TSource> zeroCollection,
         out IList<TSource> nonzeroCollection)
    {
        var zeroCollection = new List<TSource>();
        var nonzeroCollection = new List<TSource>();
        var splitSource = source.Split(2);
        foreach (var splitElement in splitSource)
        {
            // the splitElement has a length of 2 or less
            // Check if the sum is zero
            if (splitElement.Count == 2 
                && keySelector(splitElement[0]) == -keySelector(splitElement[1])
            {   // 2 elements, and sum is zero
                zeroCollection.AddRange(splitElement);
            }
            else
            {   // either only 1 element or non zero sum
                nonzeroCollection.AddRange(splitElement);
            }
        }
    }
