    public static T[,] ToMultidimensional<T>(this T[][] arr, int maxSize)
    {
        T[,] md = (T[,])Array.CreateInstance(typeof(double), arr.Length, maxSize);
        for (int i = 0; i < arr.Length; i++)
	    for (int j = 0; j < arr[i].Length; j++)
	        md[i, j] = arr[i][j];
        return md;
    }
    var arr = new List<double[]>
    {
        new double[] { 1, 2, 3 },
        new double[] { 4, 5 }
    }
    .ToArray();
    
    var j = arr.ToMultidimensional(arr.Max(a => a.Length));
