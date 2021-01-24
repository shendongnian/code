    bool passes = false;
    for(int i = 0; i < G.Length; i++)
    {
        List<string> temp = new List<string>();
        if(G[i].Contains(","))
        {
            temp = G[i].Split(",");
        }
        else
        {
            temp = G[i];
        }
      
        if(temp.Contains("1") && temp.Contains("4")
        {
            passes = true;
        }
    } 
    return passes;
