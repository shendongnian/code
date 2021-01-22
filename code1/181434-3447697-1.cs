    List<double> numbers = new List<double>();
    foreach(string line in File.ReadAllLines(path)) {
        foreach(string word in line.Split(' ') {
            numbers.Add(Double.Parse(word));
        }
    }
