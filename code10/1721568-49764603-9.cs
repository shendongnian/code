    public static int LargestPartition(this int n, int maxPartitionSize) {
        var factors = n.PrimeFactors().Where(f => f < maxPartitionSize);
        if (factors.Any()) {
        var flist = factors.OrderByDescending(f => f).ToList();
            var partition = flist.First();
            foreach (var f in flist.Skip(1)) {
                var tp = partition * f;
                if (tp <= maxPartitionSize)
                    partition = tp;
            }
            return partition;
        }
        else
            return n;
    }
