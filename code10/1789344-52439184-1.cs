    using System.Globalization;
    using System.IO;
    using System.Linq;
    ... 
    Employee[] data = File
      .ReadLines(@"employees.txt")
      .Where(line => !string.IsNullOrWhiteSpace(line)) // skip empty lines if we have them
      .Select(line => line.Split(','))
      .Select(items => new Employee(
         items[0], 
         int.Parse(items[1]), 
         decimal.Parse(items[2], CultureInfo.InvariantCulture),
         double.Parse(items[3], CultureInfo.InvariantCulture)))
      .ToArray();
