    var results = new List<int>();
    
    for (var i = 0; i < input.Length; i++)
    {
       // how we check
       var current = new List<int>();
       // just to know if we are are going down
       var lastValue = input[i];
       // second loop make sure we stop if the numbers aren't going down
       for (var j = i; j < input.Length && input[j] <= lastValue; j++)
       {
          current.Add(input[j]);
          lastValue = input[j];
       }
       // Update the result depending on the criteria 
       if (current.Count >= results.Count)
       {
          results = current;
       }
    }
    // print your awesome numbers
    foreach (var value in results)
    {
       Console.Write($"{value}, ");
    }
    
