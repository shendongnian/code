    List<double> input = new List<double>();
    List<double> time = new List<double>();
    List<double> censor = new List<double>();
    
    var results = new double[input.Count][];
    for (var i = 0; i < input.Count; i++)
       results[i] = new []{ input[i] , time[i] , censor[i] };
