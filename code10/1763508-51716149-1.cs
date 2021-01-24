    public static int Mod(int[] nums) {
        int result = nums[0];
        for (int i = 1; i < nums.Length; i++) {
            // Division of zero is zero, and division by zero is only allowed with doubles.
            if (result == 0 || nums[i] == 0)
                return 0;
            result %= nums[i];
        }
        return result;
    }
    public static void Main(string[] args) {
        int[] nums = new int[] { 300, 205, 90, 72, 15, 6 };
        Console.WriteLine($"Result: {Mod(nums)}");
        Console.ReadKey();
    }
