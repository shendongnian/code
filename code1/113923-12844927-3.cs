    static void Main(string[] args)
    {
        Random r = new Random();
    
        Stopwatch[] time = new[] { new Stopwatch(), new Stopwatch(), new Stopwatch(), new Stopwatch() };
    
        double[][] results = new[] { new double[Iterations], new double[Iterations], new double[Iterations], new double[Iterations] };
    
        for (var i = 0; i < Iterations; ++i)
        {
            double[] weights = new double[r.Next(MinimumWeights, MaximumWeights)];
            for (var w = 0; w < weights.Length; ++w)
            {
                weights[w] = (r.NextDouble() * (MaximumWeight - MinimumWeight)) + MinimumWeight;
            }
            var amount = r.Next(MinimumAmount, MaximumAmount);
    
            var totalWeight = weights.Sum();
            var expected = weights.Select(w => (w / totalWeight) * amount).ToArray();
    
            Action<int, DistributeDelgate> runTest = (resultIndex, func) =>
                {
                    time[resultIndex].Start();
                    var result = func(weights, amount).ToArray();
                    time[resultIndex].Stop();
    
                    var total = result.Sum();
    
                    if (total != amount)
                        throw new Exception("Invalid total");
    
                    var diff = expected.Zip(result, (e, a) => Math.Abs(e - a)).Sum() / amount;
    
                    results[resultIndex][i] = diff;
                };
    
            runTest(0, Distribute1);
            runTest(1, Distribute2);
            runTest(2, Distribute3);
            runTest(3, Distribute4);
        }
    }
