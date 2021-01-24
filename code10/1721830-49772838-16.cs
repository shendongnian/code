    int[] tests = new int[] {
      3, 5, 9, 12, 16, 41, 81, 100,  
    };
    var result = tests
      .Select(item => $"{item,3} == {Solve(item)}");
    Console.Write(string.Join(Environment.NewLine, result)); 
