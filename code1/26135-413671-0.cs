    List<int> nums = new List<int>(3); // creates a resizable array
                                       // which can hold 3 elements
    
    nums.Add(1);
    // adds item in O(1). nums.Capacity = 3, nums.Count = 1
    
    nums.Add(2);
    // adds item in O(1). nums.Capacity = 3, nums.Count = 3
    
    nums.Add(3);
    // adds item in O(1). nums.Capacity = 3, nums.Count = 3
    
    nums.Add(4);
    // adds item in O(n). Lists doubles the size of our internal array, so
    // nums.Capacity = 6, nums.count = 4
