    static public void RadixSortFloat(this float[] array, int arrayLen = -1)
        {
            // Some use cases have an array that is longer as the filled part which we want to sort
            if (arrayLen < 0) arrayLen = array.Length;
            // Cast our original array as long
            Span<float> asFloat = array;
            Span<int> a = MemoryMarshal.Cast<float, int>(asFloat);
            // Create a temp array
            Span<int> t = new Span<int>(new int[arrayLen]);
            // set the group length to 1, 2, 4, 8 or 16 and see which one is quicker
            int groupLength = 8;
            int bitLength = 32;
            // counting and prefix arrays
            // (dimension is 2^r, the number of possible values of a r-bit number) 
            var dim = 1 << groupLength;
            int groups = bitLength / groupLength;
            var count = new int[dim];
            var pref = new int[dim];
            int mask = (dim) - 1;
            int negatives = 0, positives = 0;
            // counting elements of the 1st group 
            for (int i = 0; i < arrayLen; i++)
            {
                if (a[i] < 0) negatives++;
                count[(a[i] >> 0) & mask]++;
            }
            positives = arrayLen - negatives;
            for (int c = 0, shift = 0; c < groups; c++, shift += groupLength)
            {
                pref[0] = 0;
                for (int i = 1; i < dim; i++)
                {
                    pref[i] = pref[i - 1] + count[i - 1];
                    count[i - 1] = 0;
                }
                var nextShift = shift + groupLength;
                //
                foreach (var ai in a)
                {
                    // Get the right index to sort the number in
                    int index = pref[(ai >> shift) & mask]++;
                    if (c == groups - 1)
                    {
                        // We're in the last (most significant) group, if the
                        // number is negative, order them inversely in front
                        // of the array, pushing positive ones back.
                        if (ai < 0) index = positives - (index - negatives) - 1; else index += negatives;
                    }
                    else count[(ai >> nextShift) & mask]++;
                    //
                    t[index] = ai;
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
