    public static int[] TwoSum(int[] nums, int target)
    {
        int[] indexes = Enumerable.Range(0, nums.Length).ToArray();
        var result =  from i in indexes
                      from j in indexes
                      where i != j && (nums[i] + nums[j]) == target
                      select new []
                      {
                          i,
                          j
                      };
        return result.FirstOrDefault();
    }
