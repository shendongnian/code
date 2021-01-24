    public static void RecursiveCopy<TInput, TOutput>(
        Array source,
        Array destination,
        int[] dimensions,
        Func<TInput, TOutput> mutate,
        int[] indexPrefix = null)
    {
        indexPrefix = indexPrefix ?? new int[0];
        if (dimensions.Length != 1)
        {
            for (var i = 0; i < dimensions[0]; i++)
            {
                var newDimensions = new int[dimensions.Length - 1];
                Array.Copy(dimensions, 1, newDimensions, 0, dimensions.Length - 1);
                
                var newIndexPrefix = new int[indexPrefix.Length + 1];
                Array.Copy(indexPrefix, 0, newIndexPrefix, 0, indexPrefix.Length);
                newIndexPrefix[indexPrefix.Length] = i;
                
                RecursiveCopy(source, destination, newDimensions, mutate, newIndexPrefix);
            }
        }
        else
        {
            var currentIndex = new int[indexPrefix.Length + 1];
            Array.Copy(indexPrefix, 0, currentIndex, 0, indexPrefix.Length);
            for (var i = 0; i < dimensions[0]; i++)
            {
                currentIndex[indexPrefix.Length] = i;
                var value = source.GetValue(currentIndex);
                if (value is TInput)
                {
                    var mutated = mutate((TInput)value);
                    destination.SetValue(mutated, currentIndex);
                }
                else
                {
                    throw new ArgumentException("Different type. Expected " + nameof(TInput));
                }
            }
        }
    }
