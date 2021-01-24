    public static int LargestPartition(this int n, int maxPartitionSize) {
        if (n >= maxPartitionSize)
            return n;
        else {
            var factors = n.PrimeFactors().Where(f => f < maxPartitionSize).OrderByDescending(f => f).ToList();
            var partition = factors.First();
            foreach (var f in factors.Skip(1)) {
                var tp = partition * f;
                if (tp <= maxPartitionSize)
                    partition = tp;
            }
            return partition;
        }
    }
