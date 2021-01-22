    string input = "I loove this post!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!aa";
    
    int index = -1;
    int count =1;
    List<string> dupes = new List<string>();
    
    for (int i = 0; i < input.Length-1; i++)
    {
        if (input[i] == input[i + 1])
        {
            if (index == -1)
                index = i;
    
            count++;
        }
        else if (index > -1)
        {
            dupes.Add(input.Substring(index, count));
            index = -1;
            count = 1;
        }
    }
    
    if (index > -1)
    {
        dupes.Add(input.Substring(index, count));
    }
