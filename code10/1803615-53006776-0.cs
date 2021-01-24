    private static Tuple<int, int> getMaxSum(int[] a, int k) {
      int sum = a.Take(k).Sum();
      int max = sum;
      int index = 0;
      for (int i = k; i < a.Length; ++i) {
        sum = sum - a[i - k] + a[i];
        if (sum > max) {
          max = sum;
          index = i - k + 1;
        }
      }
      return Tuple.Create(max, index);
    }
    ...
    int a[] = new int[] {
      2, 1, 3, 2, 4, 6, 7, 9, 1};
    var result = getMaxSum(a, 3);
    Console.Write($"Sum is {result.Item1}; starting index is {result.Item2}");
