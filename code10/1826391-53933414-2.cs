    static void Main(string[] args)
    {
        double value = 0.9;
        int degree = 5;
        var chart = new System.Web.UI.DataVisualization.Charting.Chart();
        double resultTest = chart.DataManipulator.Statistics.InverseTDistribution(value, degree);  
        Console.WriteLine(resultTest);
        //left-tailed 
        double result = alglib.invstudenttdistribution(degree, value);
        Console.WriteLine(result);
    }
