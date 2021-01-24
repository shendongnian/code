    private static int[] getConsecutiveSum(int[] a, int k)
    {
        int[] result = new int[2];
        var maxSum = a.Select((s, i) => new { Sum = a.Skip(i).Take(k).Sum(), Index = i })
                      .OrderByDescending(o => o.Sum)
                      .First();
        result[0] = maxSum.Sum;
        result[1] = maxSum.Index;
        return result;
    }
