    Random rand = new Random(Environment.TickCount);
    
    test.Sort((string v1, string v2) => {
                    if (v1.Equals(v2))
                    {
                        return 0;
                    }
    
                    int x = rand.Next();
                    int y = rand.Next();
    
                    if (x == y)
                    {
                        return 0;
                    }
                    else if (x > y)
                    {
                        return 1;
                    }
    
                    return -1; 
                });
    
    for (string item in test)
    {
      Console.WriteLn(item);
    }
    // Note that test is List<string>;
