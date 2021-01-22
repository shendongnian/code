    var dict = Dictionary<int, int>();
    for (int j=0; j<blocks_count; j++)
    {
        int count;
        if (dict.TryGetValue(block[j], out count)) // block seen before, so increment
        {
            dict[block[j]] = count + 1;
        }
        else // first time seeing this block, so set count to 1
        {
            dict[block[j]] = 1; 
        }
    }
