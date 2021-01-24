    var total = 0.0d;
    foreach (var line in File.ReadLines(//FilePath))
    {
        var lineArr = line.Split(',');
        
        double lineDonation;
        if (double.TryParse(lineArr[2])
            total += lineDonation;
    }
