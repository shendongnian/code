    static void Main(string[] args)
    {
        var chart = new System.Web.UI.DataVisualization.Charting.Chart();
        double resultTest = chart.DataManipulator.Statistics.InverseTDistribution(.9, 5);
    
        Console.WriteLine(resultTest);
    }
