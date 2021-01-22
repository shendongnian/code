    int[] singleDimensionArray = new int[10];
    int[][] multiJagged = new int[10][];
    Debug.WriteLine(singleDimensionArray is IEnumerable<int>);
    Debug.WriteLine(multiJagged is IEnumerable<int[]>);
    Debug.WriteLine(singleDimensionArray is IEnumerable);
    Debug.WriteLine(multiJagged is IEnumerable);
