    public static IEnumerable<Tuple<int[], object>> GetAllIndicesAndItems(this Array array)
    {
        if (array.Length == 0)
        {
            yield break;
        }
            
        var dimensionLengths = Enumerable.Range(0, array.Rank).Select(array.GetLength).ToArray();
        var indexColumns =
            dimensionLengths.Select(
                length =>
                    Enumerable.Repeat(Enumerable.Range(0, length).ToArray(), array.Length / length)
                        .SelectMany(x => x)
                        .OrderBy(x => x)
                        .ToArray()).ToArray();
        for (var i = 0; i < array.Length; i++)
        {
            var indices = new int[indexColumns.Length];
            for (var j = 0; j < indexColumns.Length; j++)
            {
                indices[j] = indexColumns[j][i];
            }
            yield return new Tuple<int[], object>(indices, array.GetValue(indices));
        }
    }
