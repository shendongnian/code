    // value contains the value to find.
    
    int skip;
    for (int i = 0; i < array.Length; i++)
    {
        if (array[i] == value)
        {
            skip = i;
            break;
        }
    }
    
    // skip contains the index of the element to put at the front.
    // Equivalently, it is the number of items to skip.
    // (I chose this name for it because it makes the subtractions
    // in the Array.Copy implementation more intuitive.)
