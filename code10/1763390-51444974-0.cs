    int[] arr = { 9, 8, 7, 9, 5, 4, 10, 3, 12 };
    int maxSum = 0;
    int curSum = 0;
    for(int i = 0; i < arr.Length; i++)
    {
        // new sequence
        if(curSum == 0)
        {
            curSum = arr[i];
        }
        // seqence decreasing
        else if(arr[i] <= arr[i - 1])
        {
            curSum += arr[i];
        }
        // end of sequence
        else
        {
            // check if the sequence produced a greater sum
            if(maxSum < curSum)
            {
                maxSum = curSum;
            }
            Console.WriteLine(curSum);
            curSum = arr[i];
        }
    }
    Console.WriteLine(curSum);
    // final check
    if(curSum > maxSum)
    {
        maxSum = curSum;
    }
    Console.WriteLine($"Max: {maxSum}");
