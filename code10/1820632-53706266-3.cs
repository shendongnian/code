    var tests = new string[][] {
      new string[] { "081218", "0908"},
      new string[] { "071218", "0919"},
    };
    DateTime[] result = tests
      .Select(line => new {
        TrasnactionDate = line[0],
        TrasnactionTime = line[1],
      })
      .Select(item => 
         DateTime.ParseExact(item.TrasnactionDate, 
                            "ddMMyy", 
                             CultureInfo.InvariantCulture) +
         DateTime.ParseExact(item.TrasnactionTime, 
                            "HHmm", 
                             CultureInfo.InvariantCulture).TimeOfDay)
      .ToArray();
      string report = string.Join(Environment.NewLine, result
        .Select(date => $"{date:yyyy/MM/dd HH:mm}"));
