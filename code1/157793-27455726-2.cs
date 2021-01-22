    var dimensionLengthRanges = Enumerable.Range(0, myArray.Rank).Select(x => Enumerable.Range(0, myArray.GetLength(x)));
    var indicesCombinations = dimensionLengthRanges.CartesianProduct();
    foreach (var indices in indicesCombinations)
    {
        Console.WriteLine("[{0}] = {1}", string.Join(",", indices), myArray.GetValue(indices.ToArray()));
    }
