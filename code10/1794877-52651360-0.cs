    using System;
    using System.Collections.Generic;
    {
        class Program
        {
            static void Main(string[] args)
            {
                double[] bins1 = { 145.56, 246.44, 346.55, 204.78 };
                double[] values1 = { 14, 30, 58, 49 };
    
                double[] bins2 = { 151.62, 223.18, 389.78, 266.96 };
                double[] values2 = { 67, 56, 23, 47 };
    
                int binSize = 50;
    
                Dictionary<int, double> summedBins = new Dictionary<int, double>();
    
                AddValuesToSummedBins(binSize, summedBins, bins1, values1);
                AddValuesToSummedBins(binSize, summedBins, bins2, values2);
    
    
            }
    
            public static void AddValuesToSummedBins(int binSize, Dictionary<int, double> SummedBins, double[] Bins, double[] Values)
            {
                int i = 0;
                foreach (double oneBin in Bins)
                {
                    int binSet = binSize * ((int) oneBin / binSize);
                    if (!SummedBins.ContainsKey(binSet))
                    {
                        SummedBins.Add(binSet, Values[i]);
                    }
                    else
                    {
                        SummedBins[binSet] += Values[i];
                    }
                    i++;
                }
    
                
            }
        }
    }
