    Random random = new Random();
    
    int[] nums = new int[100];
    
    // when for loop ends, nums are full of 100 numbers
    for (int i = 0; i <= nums.Length; i++)
    {
        int newNum = random.Next(0, 1001);
        // show every number
        Console.WriteLine(newNum);
    
        nums[i] = newNum;
    }
    
    // get the max number
    var maxNum = nums.Max();
    
    Console.WriteLine(maxNum);
