    public static class MyExtensions
    {
        public static DataTable GetDataTable(this List<List<double>> vs) //You can even make it Generic
        {
            DataTable result = new DataTable();
            //TODO: Use for/foreach loops here
            return result;
        }
    }
    public static void Main(string[] args)
    {
        List<double> ValuesA = new List<double>(){0.1,0.2,0.3};
        List<double> ValuesB = new List<double>(){0.4,0.5,0.6};
        List<double> ValuesC = new List<double>(){0.7,0.8,0.9};
        List<double> ValuesD = new List<double>(){1.1,1.2,1.3};
        var nlist = new List<List<double>>() { ValuesA, ValuesB, ValuesC, ValuesD };
        DataTable table = nlist.GetDataTable();
    }
