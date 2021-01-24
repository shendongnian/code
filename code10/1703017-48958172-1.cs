    if (line.StartsWith("(")) {
        line = line.Substring(1);
    }
    if (line.EndsWith(")")) {
        line = line.Substring(0, line.Length - 1);
    }
    string[] input = line.Split(new[]{',', ' '}, 
