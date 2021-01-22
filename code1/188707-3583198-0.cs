    internal static class Program
    {
        private static void Main(string[] args)
        {
            string[] array = new [] { "aaa", "bbb", "ccc" };
            DataSet dataSet = array.ToDataSet();
        }
        private static DataSet ToDataSet(this string[] input)
        {
            DataSet dataSet = new DataSet();
            DataTable dataTable = dataSet.Tables.Add();
            dataTable.Columns.Add();
            Array.ForEach(input, c => dataTable.Rows.Add()[0] = c);
            return dataSet;
        }
    }
