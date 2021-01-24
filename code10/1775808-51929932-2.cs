    public static IEnumerable<IEnumerable<int>> Transpose(this int[][] array2D)
    {
         // TODO: check input
         int nrOfColumns = array2D.First().Length;
         for(int columNr = 0; columNr < nrOfColumns; ++columNr)
         {
              yield return array2D.Select(row => row[columnNr];
         }
    }
    public static IEnumerable<int> ToVerticalAverage(this int[][] array2D)
    {
        // TODO: check input
        foreach (IEnumerable<int> column in array2D.Transpose())
        {
             yield return column.Average();
        }
