    private static int[] GetPrimeArray(int floor, int ceiling)
    {
        // Validate arguments.
        if (floor > int.MaxValue - 1)
            throw new ArgumentException("Floor is too high. Max: 2,147,483,646");
        else if (ceiling > int.MaxValue - 1)
            throw new ArgumentException("Ceiling is too high. Max: 2,147,483,646");
        else if (floor < 0)
            throw new ArgumentException("Floor must be a positive integer.");
        else if (ceiling < 0)
            throw new ArgumentException("Ceiling must be a positve integer.");
        else if (ceiling < floor)
            throw new ArgumentException("Ceiling cannot be less than floor.");
        // This region is only useful when testing performance.
        #region Performance
        Stopwatch sw = new Stopwatch();
        sw.Start();
        #endregion
        // Variables:
        int stoppingPoint = (int)Math.Sqrt(ceiling);
        double rosserBound = (1.25506 * (ceiling + 1)) / Math.Log(ceiling + 1, Math.E);
        int[] primeArray = new int[(int)rosserBound];
        int primeIndex = 0;
        int bitIndex = 4;
        int innerIndex = 3;
        // Handle single digit prime ranges.
        if (ceiling < 11)
        {
            if (floor <= 2 && ceiling >= 2) // Range includes 2.
                primeArray[primeIndex++] = 2;
            if (floor <= 3 && ceiling >= 3) // Range includes 3.
                primeArray[primeIndex++] = 3;
            if (floor <= 5 && ceiling >= 5) // Range includes 5.
                primeArray[primeIndex++] = 5;
            return primeArray;
        }
        // Begin Sieve of Eratosthenes. All values initialized as true.
        BitArray primeBits = new BitArray(ceiling + 1, true); 
        primeBits.Set(0, false); // Zero is not prime.
        primeBits.Set(1, false); // One is not prime.
        checked // Check overflow.
        {
            try
            {
                // Set even numbers, excluding 2, to false.
                for (bitIndex = 4; bitIndex < ceiling; bitIndex += 2)
                    primeBits[bitIndex] = false;
            }
            catch { } // Break for() if overflow occurs.
        }
        // Iterate by steps of two in order to skip even values.
        for (bitIndex = 3; bitIndex <= stoppingPoint; bitIndex += 2)
        {
            if (primeBits[bitIndex] == true) // Is prime.
            {
                // First position to unset is always the squared value.
                innerIndex = bitIndex * bitIndex;
                primeBits[innerIndex] = false;
                checked // Check overflow.
                {
                    try
                    {
                        // Set multiples of i, which are odd, to false.
                        innerIndex += bitIndex + bitIndex;
                        while (innerIndex <= ceiling)
                        {
                            primeBits[innerIndex] = false;
                            innerIndex += bitIndex + bitIndex;
                        }
                    }
                    catch { continue; } // Break while() if overflow occurs.
                }
            }
        }
        // Set initial array values.
        if (floor <= 2)
        {
            // Range includes 2 - 5.
            primeArray[primeIndex++] = 2;
            primeArray[primeIndex++] = 3;
            primeArray[primeIndex++] = 5;
        }
        else if (floor <= 3)
        {
            // Range includes 3 - 5.
            primeArray[primeIndex++] = 3;
            primeArray[primeIndex++] = 5;
        }
        else if (floor <= 5)
        {
            // Range includes 5.
            primeArray[primeIndex++] = 5;
        }
        // Increment values that skip multiples of 2, 3, and 5.
        int[] increment = { 6, 4, 2, 4, 2, 4, 6, 2 };
        int indexModulus = -1;
        int moduloSkipAmount = (int)Math.Floor((double)(floor / 30));
        // Set bit index to increment range which includes the floor.
        bitIndex = moduloSkipAmount * 30 + 1;
        // Increase bit and increment indicies until the floor is reached.
        for (int i = 0; i < increment.Length; i++)
        {
            if (bitIndex >= floor)
                break; // Floor reached.
            // Increment, skipping multiples of 2, 3, and 5.
            bitIndex += increment[++indexModulus];
        }
        // Initialize values of return array.
        while (bitIndex <= ceiling)
        {
            // Add bit index to prime array, if true.
            if (primeBits[bitIndex])
                primeArray[primeIndex++] = bitIndex;
            checked // Check overflow.
            {
                try
                {
                    // Increment. Skip multiples of 2, 3, and 5.
                    indexModulus = ++indexModulus % 8;
                    bitIndex += increment[indexModulus];
                }
                catch { break; } // Break if overflow occurs.
            }
        }
        // Resize array. Rosser-Schoenfeld upper bound of π(x) is not an equality.
        Array.Resize(ref primeArray, primeIndex);
        // This region is only useful when testing performance.
        #region Performance
        sw.Stop();
        if (primeArray.Length == 0)
            Console.WriteLine("There are no prime numbers between {0} and {1}",
                floor, ceiling);
        else
        {
            Console.WriteLine(Environment.NewLine);
            for (int i = 0; i < primeArray.Length; i++)
                Console.WriteLine("{0,10}:\t\t{1,15:#,###,###,###}", i + 1, primeArray[i]);
        }
        Console.WriteLine();
        Console.WriteLine("Calculation time:\t{0}", sw.Elapsed.ToString());
        #endregion
        return primeArray;
    }
