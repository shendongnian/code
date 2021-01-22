    public static List<int> RandomListByIncrementing(int digitMin, int digitMax, 
                                                     int targetSum, int numDigits)
    {
        if(targetSum < digitMin * numDigits || targetSum > digitMax * numDigits)
            throw new ArgumentException("Impossible!", "targetSum");
        List<int> ret = new List<int>(Enumerable.Repeat(digitMin, numDigits));
        List<int> indexList = new List<int>(Enumerable.Range(0, numDigits-1));
        Random random = new Random();
        int index;
    
        for(int currentSum=numDigits * digitMin; currentSum<targetSum; currentSum++)
        {
            //choose a random digit in the list to increase by 1
            index = random.Next(0,indexList.Length-1);
            if(++ret[indexList[index]] == digitMax)
            {
                //if you've increased it up to the max, remove its reference
                //because you can't increase it anymore
                indexList.RemoveAt(index);
            }
        }
            
        return ret;
    }
