    foreach( var pair in allOffset )
    {
      foreach( var innerPair in pair.Value )
      {
        Console.WriteLine("{0}->>{1},{2}", pair.Key, innerPair.Key, innerPair.Value);
      }
    }
