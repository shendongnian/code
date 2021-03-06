    public static int[] GetUniqueInt(int intCount)
    {
        int[] returnValue = new int[intCount];
        var values = new HashSet<int>(); // Used to track what numbers we have generated
        for (int i = 0; i < intCount; ++i)
        {
            // Generate the number and check to be sure we haven't seen it yet
            var number = GetRandomInt(intCount);
            while(values.Contains(number)) // This checks if the number we just generated exists in the HashSet of seen numbers
            {
                // We get here if the HashSet contains the number. If we have
                // seen the number then we need to generate a different one
                number = GetRandomInt(intCount);
            }
            
            // When we reach this point, it means that we have generated a new unique number
            // Add the number to the return array and also add it to the list of seen numbers             
            returnValue[a] = number;
            values.Add(number); // Adds the number to the HashSet
        }
        Debug.Log(returnValue);
        return returnValue;
    }
