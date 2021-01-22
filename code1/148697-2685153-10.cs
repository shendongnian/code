    public static float[] RadixSort(this float[] array)
    {
        // temporary array and the array of converted floats to ints
        int[] t = new int[array.Length];
        int[] a = new int[array.Length];
        for (int i = 0; i < array.Length; i++)
            a[i] = BitConverter.ToInt32(BitConverter.GetBytes(array[i]), 0);
        // set the group length to 1, 2, 4, 8 or 16
        // and see which one is quicker
        int groupLength = 4;
        int bitLength = 32;
        // counting and prefix arrays
        // (dimension is 2^r, the number of possible values of a r-bit number) 
        int[] count = new int[1 << groupLength];
        int[] pref = new int[1 << groupLength];
        int groups = bitLength / groupLength;
        int mask = (1 << groupLength) - 1;
        int negatives = 0, positives = 0;
        for (int c = 0, shift = 0; c < groups; c++, shift += groupLength)
        {
            // reset count array 
            for (int j = 0; j < count.Length; j++)
                count[j] = 0;
            // counting elements of the c-th group 
            for (int i = 0; i < a.Length; i++)
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
            for (int i = 1; i < count.Length; i++)
                pref[i] = pref[i - 1] + count[i - 1];
            // from a[] to t[] elements ordered by c-th group 
            for (int i = 0; i < a.Length; i++){
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
            // a[]=t[] and start again until the last group 
            t.CopyTo(a, 0);
        }
        // Convert back the ints to the float array
        float[] ret = new float[a.Length];
        for (int i = 0; i < a.Length; i++)
            ret[i] = BitConverter.ToSingle(BitConverter.GetBytes(a[i]), 0);
        return ret;
    }
