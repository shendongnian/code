    static public void RadixSortFloat(this float[] array, int arrayLen = -1)
            {
                // Some use cases have an array that is longer as the filled part which we want to sort
                if (arrayLen < 0) arrayLen = array.Length;
                // Cast our original array as long
                Span<float> asFloat = array;
                Span<int> t = MemoryMarshal.Cast<float, int>(asFloat);
                // Create a temp array
                Span<int> a = new Span<int>(new int[arrayLen]);
    
                // set the group length to 1, 2, 4, 8 or 16
                // and see which one is quicker
                int groupLength = 16;
                int bitLength = 32;
    
                // counting and prefix arrays
                // (dimension is 2^r, the number of possible values of a r-bit number) 
                var dim = 1 << groupLength;
                var count = new int[dim];
                var pref = new int[dim];
                int groups = bitLength / groupLength;
                int mask = (dim) - 1;
                int negatives = 0, positives = 0;
    
                for (int c = 0, shift = 0; c < groups; c++, shift += groupLength)
                {
                    // reset count array 
                    for (int j = 0; j < dim; j++) count[j] = 0;
    
                    // counting elements of the c-th group 
                    for (int i = 0; i < arrayLen; i++)
                    {
                        count[(a[i] >> shift) & mask]++;
    
                        // additionally count all negative 
                        // values in first round
                        if (c == 0 && a[i] < 0)
                            negatives++;
                    }
                    if (c == 0) positives = a.Length - negatives;
    
                    // calculating prefixes
                    pref[0] = 0;
                    for (int i = 1; i < dim; i++) pref[i] = pref[i - 1] + count[i - 1];
    
                    // from a[] to t[] elements ordered by c-th group 
                    for (int i = 0; i < a.Length; i++)
                    {
                        // Get the right index to sort the number in
                        int index = pref[(a[i] >> shift) & mask]++;
    
                        if (c == groups - 1)
                        {
                            // We're in the last (most significant) group, if the
                            // number is negative, order them inversely in front
                            // of the array, pushing positive ones back.
                            if (a[i] < 0)
                                index = positives - (index - negatives) - 1;
                            else
                                index += negatives;
                        }
                        t[index] = a[i];
                    }
    
                    // swap the arrays and start again until the last group 
                    var temp = a;
                    a = t;
                    t = temp;
                }
    
                // Convert back the ints to the float array if we did an uneven number of copy swap runs
                if (groups % 2 != 0)
                {
                    asFloat = MemoryMarshal.Cast<int, float>(a);
                    for (int i = 0; i < arrayLen; i++) array[i] = asFloat[i];
                }
            }
