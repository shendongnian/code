    using System;
    using System.Linq;
    using MathNet.Numerics.Random;
    using MathNet.Numerics.Distributions;
    
    namespace EqualizedSampling
    {
        class Program
        {
            static void Main(string[] args)
            {
                int guidanceParameter = 1000000; // Small one - consequtive sampling is more affected by outcome. Large one - closer to uniform sampling
    
                int[]    invprob = new int [6];
                double[] probabilities = new double [6];
    
                int[] counter = new int [] {0, 0, 0, 0, 0, 0};
                int[] repeat  = new int [] {0, 0, 0, 0, 0, 0};
                int prev = -1;
                for(int k = 0; k != 100000; ++k ) {
                    if (k % 60 == 0 ) { // drop accumulation, important for low guidance
                        for(int i = 0; i != 6; ++i) {
                            invprob[i] = guidanceParameter;
                        }
                    }
                    for(int i = 0; i != 6; ++i) {
                        probabilities[i] = 1.0/(double)invprob[i];
                    }
                    var cat = new Categorical(probabilities);
                    var q = cat.Sample();
                    counter[q] += 1;
                    invprob[q] += 1;
                    if (q == prev)
                        repeat[q] += 1;
                    prev = q;
                }
                counter.ToList().ForEach(Console.WriteLine);
                repeat.ToList().ForEach(Console.WriteLine);
            }
        }
    }
