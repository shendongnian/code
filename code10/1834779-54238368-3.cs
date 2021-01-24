    var fileName = "input.txt";
    var lines = File.ReadAllLines(fileName);//.Skip(1) // if you have an header.
    var rawData = lines.Select(line => line.Split(';'))
                        .Select(item =>
                        {
                             Decimal lon, lat;
                             return new
                             {
                                 date = DateTime.Parse(item[0]),
                                 Lon = Decimal.TryParse(item[1], out lon) ? lon : 0,
                                 Lat = Decimal.TryParse(item[2], out lat) ? lat : 0,
                             };
                         });
