    var fileName = @"FileName";
    var rawLines[] = File.ReadAllLines(fileName);
    var ids = new List<int>();
    var maxSizes = new List<int>();
    var taxes = new List<double>();
    foreach(var line in rawLines) {
        var data = line.Split(' ');
        ids.Add(Convert.ToInt32(data[0]));
        maxSizes.Add(Convert.ToInt32(data[1]));
        taxes.Add(Convert.ToDouble(data[2]));
    }
    // using lists
    Console.WriteLine($"First Data - {ids[0]}  {maxSizes[0]}  {taxes[0]}");
 
