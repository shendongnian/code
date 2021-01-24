    using System;
    using System.Linq;
    namespace EqualizedSampling
    {
        class Program
        {
            static Random rnd = new Random(DateTime.Now.Millisecond);
            /// <summary>
            /// Returns a random int number from [0 .. numNumbers-1] range using probabilities.
            /// Probabilities have to add up to 1.
            /// </summary>
            static int Sample(int numNumbers, double[] probabilities)
            {
                // probabilities have to add up to 1
                double r = rnd.NextDouble();
                double sum = 0.0;
                for (int i = 0; i < numNumbers; i++)
                {
                    sum = sum + probabilities[i];
                    if (sum > r)
                        return i;
                }
                return numNumbers - 1;
            }
            static void Main(string[] args)
            {
                const int numNumbers = 6;
                const int numSamples = 30;
                // low ratio makes everything behave more random
                // min is 1.0 which makes things behave like a random number generator.
                // higher ratio makes number selection more "natural"
                double ratio = 5.0;
                double[] probabilities = new double[numNumbers];
                int[] counter = new int[numNumbers];        // how many times number occured
                int[] maxRepeat = new int[numNumbers];      // how many times in a row this number (max)
                int[] maxDistance = new int[numNumbers];    // how many samples happened without this number (max)
                int[] lastOccurence = new int[numNumbers];  // last time this number happened
                // init
                for (int i = 0; i < numNumbers; i++)
                {
                    counter[i] = 0;
                    maxRepeat[i] = 0;
                    probabilities[i] = 1.0 / numNumbers;
                    lastOccurence[i] = -1;
                }
                int prev = -1;
                int numRepeats = 1;
                for (int k = 0; k < numSamples; k++)
                {
                    // sample next number
                    //var cat = new Categorical(probabilities);
                    //var q = cat.Sample();
                    var q = Sample(numNumbers, probabilities);
                    Console.Write($"{q}, ");
                    // affect probability of the selected number
                    probabilities[q] /= ratio;
                    // rescale all probabilities so they add up to 1
                    double sumProbabilities = 0;
                    probabilities.ToList().ForEach(d => sumProbabilities += d);
                    for (int i = 0; i < numNumbers; i++)
                        probabilities[i] /= sumProbabilities;
                    // gather statistics
                    counter[q] += 1;
                    numRepeats = q == prev ? numRepeats + 1 : 1;
                    maxRepeat[q] = Math.Max(maxRepeat[q], numRepeats);
                    lastOccurence[q] = k;
                    for (int i = 0; i < numNumbers; i++)
                        maxDistance[i] = Math.Max(maxDistance[i], k - lastOccurence[i]);
                    prev = q;
                }
                Console.WriteLine("-\n");
                Console.WriteLine("Number of occurences:");
                counter.ToList().ForEach(Console.WriteLine);
                Console.WriteLine();
                Console.WriteLine("Max occurences in a row:");
                maxRepeat.ToList().ForEach(Console.WriteLine);
                Console.WriteLine();
                Console.WriteLine("Max length where this number did not occur:");
                maxDistance.ToList().ForEach(Console.WriteLine);
                Console.ReadLine();
            }
        }
    }
