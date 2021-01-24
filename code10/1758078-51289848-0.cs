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
        public double DotDoubleVector()
        {
             double returnVal = 0.0;
             for(int i = 0; i < ITEMS; i += doubleSlots)
             {
                returnVal += Vector.Dot(new Vector<double>(doubleArray, i), new Vector<double>(doubleArray2, i));
             }
                        
           return returnVal;  
    }
    BenchmarkDotNet=v0.10.14, OS=Windows 10.0.17134
    Intel Core i7-4500U CPU 1.80GHz (Haswell), 1 CPU, 4 logical and 2 physical cores
    Frequency=1753758 Hz, Resolution=570.2041 ns, Timer=TSC
    .NET Core SDK=2.1.300
      [Host]     : .NET Core 2.1.0 (CoreCLR 4.6.26515.07, CoreFX 4.6.26515.06), 64bit RyuJIT
      DefaultJob : .NET Core 2.1.0 (CoreCLR 4.6.26515.07, CoreFX 4.6.26515.06), 64bit RyuJIT
    
    
              Method |      Mean |     Error |    StdDev | Scaled |
    ---------------- |----------:|----------:|----------:|-------:|
           DotDouble | 10.489 us | 0.1618 us | 0.1434 us |   1.00 |
     DotDoubleVector |  5.898 us | 0.0320 us | 0.0268 us |   0.56 |
