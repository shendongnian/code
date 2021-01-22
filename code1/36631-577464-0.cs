        double input = 100;
        const int Buckets = 7;
        double[] vals = new double[Buckets];
        for (int i = 0; i < vals.Length; i++)
        {
            vals[i] = Math.Floor(input / Buckets);
        }
        double remainder = input % Buckets;
        // give all of the remainder to the first value
        vals[0] += remainder;
