    public static List<int> RandomListByIncrementing(int digitMin, int digitMax, 
                                                     int targetSum, int numDigits)
    {
        if(targetSum < digitMin * numDigits || targetSum > digitMax * numDigits)
            throw new ArgumentException("Impossible!", "targetSum");
        List<int> ret = new List<int>(numDigits);
        List<int> tempList = new List<int>(numDigits);
    
        for (int i=0; i<numDigits; i++)
            tempList.Add(digitMin);
        Random random = new Random();
        int index;
    
        for(int currentSum=numDigits * digitMin; currentSum<targetSum; currentSum++)
        {
            //choose a random digit in the list to increase by 1
            index = random.Next(0,tempList.Length-1);
            if(++tempList[index] == digitMax)
            {
                //if you've increased it up to the max, remove it
                //because you can't increase it anymore
                ret.Add(tempList[index]);
                tempList.RemoveAt(index);
            }
        }
        //add the digits that haven't been added yet
        tempList.ForEach(digit => ret.Add(digit));
            
        return ret;
    }
