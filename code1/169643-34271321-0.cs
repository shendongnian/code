    IEnumerable<object> myData = new List<object>() { "53.2", 53.2M, 53.2D };
    const int iterations = 10000000;
    var sw = new Stopwatch();
    var results = new List<string>();
    foreach (var o in myData)
    {
    	sw.Reset();
    	sw.Start();
    	for (var i=0; i < iterations; i++)
    	{
    		double d = (o is double) ? (double)o
                : (o is IConvertible) ? (o as IConvertible).ToDouble(null)
                : double.Parse(o.ToString());
    	}
    	sw.Stop();
    	results.Add($"{o.GetType()}: {iterations} iterations took {sw.ElapsedMilliseconds}ms");
    }
    results.Dump();
