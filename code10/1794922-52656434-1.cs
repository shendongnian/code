    List<List<double>> myList = new List<List<double>>()
    {
        new List<double>(){ 1, 25 },
        new List<double>(){ 2, 14 },
        new List<double>(){ 3, 30 }
    };
    ParameterExpression[] x = new ParameterExpression[] { Expression.Parameter(typeof(List<double>), "x") };
    Func<List<double>, bool> adultFilter = (Func<List<double>, bool>) System.Linq.Dynamic.DynamicExpression.ParseLambda(x, null, "x[1] > 18").Compile();
    int adults = myList.Count(adultFilter);
    Console.WriteLine("Total adults " + adults);
