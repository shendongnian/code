    string stopLine = "STOP";
    List<double> lines = new List<double>();
    string line;
    while ((line = Console.ReadLine()) != stopLine) {
        lines.Add(Convert.ToDouble(line));
    }
    Average(lines);
    Console.ReadLine();
