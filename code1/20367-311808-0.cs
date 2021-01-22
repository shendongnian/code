    int[] sums = new int[listOfArrays[0].Length];
    Enumerable.Range(0, listOfArrays[0].Length-1).
        ForEach(arrayIndex => sums[arrayIndex] = 
            Enumerable.Range(0, listOfArrays.Count-1).
                Aggregate((total, listIndex) => 
                    total += listOfArrays[listIndex][arrayIndex]));
