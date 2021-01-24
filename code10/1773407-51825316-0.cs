    List<string> initiallist = new List<string>
    {"test", "test2", "test3", "test4", "test5", "test6", "test7", "test8", "test9", "test10", "test11", "test12"};
    // We store the results here    
    List<List<string>> result = new List<List<string>>();
    
    Random rnd = new Random();
    int pos = 0;
    while (pos < initiallist.Count())
    {
        // Define a block size of 2/3 elements
        int block = rnd.Next(2,4);
        // Extract the block size from the previous position
        List<string> temp = initiallist.Skip(pos).Take(block).ToList();
        // Add the sublist to our results
        result.Add(temp);
        // Point to the beginning of the next block
        pos += block;
        
    }
