      using System.Linq;
      using System.Text.RegularExpressions;
      ...
      var rectangles = Regex
        .Split(Lines, @"\s{2,}")
        .Select(item => item.Trim())
        .Where(item => !string.IsNullOrEmpty(item))
      //.Take(3) // If you want at most 3 rectangles
        .Select(item => string.Join(Environment.NewLine, 
           Sign1, 
           Sign2 + ToCenter(item, Sign1.Length - 2) + Sign2, 
           Sign3));
      foreach (string rectangle in rectangles) {
        // print out the next rectangle
        Console.WriteLine(rectangle);
        //TODO: add all the relevant code here
        // ReadLine();
      }
