    int index = theList.BinarySearch(num);
    
    if (index >= 0)
    {
        //exists
        ...
    }
    else
    {
        // doesn't exist
        int indexOfBiggerNeighbour = ~index; //bitwise complement of the return value
    
        if (indexOfBiggerNeighbour == theList.Count)
        {
            // bigger than all elements
            ...
        }
    
        else if (indexOfBiggerNeighbour == 0)
        {
            // smaller than all elements
            ...
        }
    
        else
        {
            // Between 2 elements
            int indexOfSmallerNeighbour = indexOfBiggerNeighbour - 1;
            ...
        }
    }
