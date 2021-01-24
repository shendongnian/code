        var trials = 10;
        var trialProbability = 0.25;
        for (double p = 0;  p <= 1; p += 0.01)
        {
            var i = GetSuccesses(trials, trialProbability, p);
            Console.WriteLine($"{i} Successes out of {trials} with P={trialProbability} at {p}");
        }
        Console.ReadKey();
        
    }
    static int GetSuccesses(int N, double P, double rand)
    {
        for (int i = 0; i <= N; i++)
        {
            var p_of_i_successes = MathNet.Numerics.Distributions.Binomial.PMF(P, N, i);
            if (p_of_i_successes >= rand)
                return i;
            rand -= p_of_i_successes;
        }
        return N;
        
    }
