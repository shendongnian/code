     double[] test = System.IO.File
       .ReadLines(new_path)
       .Select(line => double.Parse(line)) // <- each line should be parsed into double
       .ToArray();
     foreach (double number in test) {
       Console.WriteLine(number);
     }         
     Console.ReadLine();
