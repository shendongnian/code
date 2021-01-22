    public static double Median(this IEnumerable<DataSet1.DataTable1Row> source)
    {
        List<double> values = source.Select(x => x.col2).ToList();
        values.Sort();
        if ((values.Count % 2) == 1) // Odd number of values
        {
            return values[values.Count/2];
        }
        else // Even number of values: find mean of middle two
        {
            return (values[values.Count/2] + values[values.Count/2 + 1]) / 2;
        }
    }
