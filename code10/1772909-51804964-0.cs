    public static int[] TwoSum(int[] nums, int target)
    {
		return
		(
			from i in Enumerable.Range(0, nums.Length)
			from j in Enumerable.Range(0, nums.Length)
			where i != j && nums[i] + nums[j] == target
			select new [] { i, j }
		).FirstOrDefault();
     }
