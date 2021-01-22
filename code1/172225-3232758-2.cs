    int[] arr1 = new int[] { 1,2,3};
    int[] arr2 = new int[] { 3,2,1 };
    
    Console.WriteLine(arr1.SequenceEqual(arr2)); // false
    Console.WriteLine(arr1.Reverse().SequenceEqual(arr2)); // true
