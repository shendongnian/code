        [Benchmark(Baseline = true)]
        public double DotDouble()
        {
            double returnVal = 0.0;
            for(int i = 0; i < ITEMS; i++)
            {
                returnVal += doubleArray[i] * doubleArray2[i];
            }
            return returnVal;
            }
        
            [Benchmark]
            public double DotDoubleVectorNaive()
            {
                 double returnVal = 0.0;
                 for(int i = 0; i < ITEMS; i += doubleSlots)
                 {
                    returnVal += Vector.Dot(new Vector<double>(doubleArray, i), new Vector<double>(doubleArray2, i));
                 }
                            
               return returnVal;  
        }
    
    [Benchmark]
            public double DotDoubleVectorBetter()
            {
                Vector<double> sumVect = Vector<double>.Zero;
                for (int i = 0; i < ITEMS; i += doubleSlots)
                {
                    sumVect += new Vector<double>(doubleArray, i) * new Vector<double>(doubleArray2, i);
                }
                return Vector.Dot(sumVect, Vector<double>.One);
            }
        BenchmarkDotNet=v0.10.14, OS=Windows 10.0.17134
        Intel Core i7-4500U CPU 1.80GHz (Haswell), 1 CPU, 4 logical and 2 physical cores
        Frequency=1753758 Hz, Resolution=570.2041 ns, Timer=TSC
        .NET Core SDK=2.1.300
          [Host]     : .NET Core 2.1.0 (CoreCLR 4.6.26515.07, CoreFX 4.6.26515.06), 64bit RyuJIT
          DefaultJob : .NET Core 2.1.0 (CoreCLR 4.6.26515.07, CoreFX 4.6.26515.06), 64bit RyuJIT
        
        
                    Method |      Mean |     Error |    StdDev | Scaled |
    ---------------------- |----------:|----------:|----------:|-------:|
                 DotDouble | 10.341 us | 0.0902 us | 0.0844 us |   1.00 |
      DotDoubleVectorNaive |  5.907 us | 0.0206 us | 0.0183 us |   0.57 |
     DotDoubleVectorBetter |  4.825 us | 0.0197 us | 0.0184 us |   0.47 |
