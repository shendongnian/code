    //Example Usage 
    int[] indexes = getRandomUniqueIndexArray(selectFrom.Length, toSet.Length, new Random());
    for(int i = 0; i < toSet.Length; i++) toSet[i] = selectFrom[indexes[i]];
    
        /// <summary>
        /// Gets a random set of indexes within a range that are all unique
        /// </summary>
        /// <param name="range">The range of available indexes</param>
        /// <param name="length">How many indexes you wish to generate</param>
        /// <param name="generator">The generator to use</param>
        /// <param name="count">Used by the recursive process, ignore it</param>
        /// <returns></returns>
        private int[] getRandomUniqueIndexArray(int range, int length, Random generator, int count = 0)
        {
            if(count == length) return new int[length]; //Recursion base case
            int myIndex = generator.Next(range - count); //Get a random index for our view of the array
            int[] toReturn = getRandomUniqueIndexArray(range, length, generator, ++count); //Get what the call beneath thinks is a set of unique random indexes
            //Adjust the results of the recursive call.
            //Anything with an index greater or equal to ours needs to be incremented so that it fits in with our wider view
            //Plus to make things more fun, we're actually building our array in reverse!
            for(int i = length; i > count;) if(toReturn[--i] >= myIndex) toReturn[i]++;
            toReturn[--count] = myIndex; //Simply assign our index into the array and return
            return toReturn;
        }
