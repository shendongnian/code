    int i = 0;
    while (i < 100)
    {
      i+=1; 
      while(i % 10 != 0)
      {
        Console.Write(i);
        i+=1;
      }
      Console.Write(Environment.NewLine);
    }
 
