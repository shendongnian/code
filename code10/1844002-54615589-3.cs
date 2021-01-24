    string[,] testArray =
    {
    	{"testValue1", "testValue1.1"},
    	{"testValue2", "testValue2.1"},
    	{"testValue3", "testValue3.1"}
    };
    Console.WriteLine(string.Join(", ", testArray.GetColumn(0))); //testValue1, testValue1.1
    
    public static class ArrayExt
    {
    	public static IEnumerable<string> GetColumn(this string[,] array, int column)
    	{
    		return Enumerable.Repeat(column, array.GetLength(1))
    			.Zip(Enumerable.Range(0, array.GetLength(1)), (x,y) => new { X = x, Y = y })
    			.Select(i => array[i.X, i.Y]);
    	}
    }
