    public int FindMaxDecreasing(int[] arr)
    {
        //Store the max value
        var max = 0;
        //The current running total
        var temp = 0;
        //Store the previous value
        var previous = 0;
        for(int i = 0; i < arr.Length; i++)
        {
             //Check if first element or decreasing value
             if(i == 0 += arr[i] < previous)
             {
                //Add to temp if it is
                temp += arr[i];
             }
             else
             { 
                 //Swap out max value if temp is larger
                 if(temp > max)
                 {
                     max = temp;
                 }
                 //Restart temp
                  temp = arr[i];
              }
             //Assign previous
             previous = arr[i];
        }
    
        if(temp > max)
        {
            max = temp;
        }
        return max;
    }
