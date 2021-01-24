    //
    // Dirichlet sampling, using Gamma sampling from Math .NET
    //
    using MathNet.Numerics.Distributions;
    using MathNet.Numerics.Random;
    static void SampleDirichlet(double alpha, double[] rn)
    {
        if (rn == null)
            throw new ArgumentException("SampleDirichlet:: Results placeholder is null");
        if (alpha <= 0.0)
            throw new ArgumentException($"SampleDirichlet:: alpha {alpha} is non-positive");
        int n = rn.Length;
        if (n == 0)
            throw new ArgumentException("SampleDirichlet:: Results placeholder is of zero size");
        var gamma = new Gamma(alpha, 1.0);
        double sum = 0.0;
        for(int k = 0; k != n; ++k) {
            double v = gamma.Sample();
            sum  += v;
            rn[k] = v;
        }
        if (sum <= 0.0)
            throw new ApplicationException($"SampleDirichlet:: sum {sum} is non-positive");
        // normalize
        sum = 1.0 / sum;
        for(int k = 0; k != n; ++k) {
            rn[k] *= sum;
        }
    }
