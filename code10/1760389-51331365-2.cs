    using System;
    using MathNet.Numerics.Distributions;
    using MathNet.Numerics.Random;
    class Program
    {
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
        static bool SampleBoundedDirichlet(double alpha, double sum, double lo, double hi, double[] rn)
        {
            if (rn == null)
                throw new ArgumentException("SampleDirichlet:: Results placeholder is null");
            if (alpha <= 0.0)
                throw new ArgumentException($"SampleDirichlet:: alpha {alpha} is non-positive");
            if (lo >= hi)
                throw new ArgumentException($"SampleDirichlet:: low {lo} is larger than high {hi}");
            int n = rn.Length;
            if (n == 0)
                throw new ArgumentException("SampleDirichlet:: Results placeholder is of zero size");
            double mean = sum / (double)n;
            if (mean < lo || mean > hi)
                throw new ArgumentException($"SampleDirichlet:: mean value {mean} is not within [{lo}...{hi}] range");
            SampleDirichlet(alpha, rn);
            bool rc = true;
            for(int k = 0; k != n; ++k) {
                double v = lo + (mean - lo)*(double)n * rn[k];
                if (v > hi)
                    rc = false;
                rn[k] = v;
            }
            return rc;
        }
        static void Main(string[] args)
        {
            double[] rn = new double [30];
            double lo = -50.0;
            double hi =  50.0;
            double alpha = 10.0;
            double sum = 300.0;
            for(int k = 0; k != 1_000; ++k) {
                var q = SampleBoundedDirichlet(alpha, sum, lo, hi, rn);
                Console.WriteLine($"Rng(BD), v = {q}");
                double s = 0.0;
                foreach(var r in rn) {
                    Console.WriteLine($"Rng(BD),     r = {r}");
                    s += r;
                }
                Console.WriteLine($"Rng(BD),    summa = {s}");
            }
        }
    }
