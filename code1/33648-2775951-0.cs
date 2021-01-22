    Dictionary<string, int> output = new Dictionary<string, int>();
    
    // read line from file
    
    ...
    
    // if need to delete line then set int value to 1
    
    // otherwise set int value to 0
    if (deleteLine)
    {
        output[line] = 1;
    }
    else
    {
        output[line] = 0;
    }
    
    // define the no delete List
    List<string> nonDeleteList = new List<string>();
    
    // use foreach to loop through each item in nonDeleteList and add each key
    // who's value is equal to zero (0) to the nonDeleteList.
    foreach (KeyValuePair<string, int> kvp in output)
    {
    
        if (kvp.Value == 0)
    
        {
    
            nonDeleteList.Add(kvp.Key);
    
        }
    }
    
    // write the nondeletelist to the output file
    File.WriteAllLines("OUTPUT_FILE_NAME", nonDeleteList.ToArray());
