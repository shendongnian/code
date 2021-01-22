    var array = new int[] { 1, 2, 3, 4, 5 };
    foreach (var value in array.WithPrevious())
    {
      Console.WriteLine("{0}, {1}", value.Previous, value.Value);
      // Results: 1, 2
      //          2, 3
      //          3, 4
      //          4, 5
    }
