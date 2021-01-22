    object[,] comInteropArray = Array.CreateInstance(
        typeof(object),
        new int[] { 3, 5 },
        new int[] { 1, 1 }) as object[,];
    System.Diagnostics.Debug.Assert(
         1 == comInteropArray.GetLowerBound(0),
        "Does it look like a COM interop array?");
    System.Diagnostics.Debug.Assert(
         1 == comInteropArray.GetLowerBound(1),
        "Does it still look like a COM interop array?");
