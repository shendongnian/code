    public static Location ConvertToLocation(string input)
    {
       var split = input.Split(';');
       return new Location(DateTime.Parse(split[0]),decimal.Parse(split[1]),decimal.Parse(split[2]));
    }
