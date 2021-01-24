    foreach (var weatherItem in data)
    {
          Console.WriteLine(weatherItem.distance);
          Console.WriteLine(weatherItem.latt_long);
          Console.WriteLine(weatherItem.location_type);
          Console.WriteLine(weatherItem.title);
          Console.WriteLine(weatherItem.woeid);
    }
