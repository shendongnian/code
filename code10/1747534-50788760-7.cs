    if (i == 6) {
      Test6(ref i);
      Console.WriteLine("Added item to dictionary.");
    } else...
    private static void Test6(ref int i) {
      myDictionary.Add(i, "six");
      Console.WriteLine("Test6 = " + myDictionary[i]);
    }
