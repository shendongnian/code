    // convert DateTime to string
    return DateTime.Now.ToString("yyyyMMddHHmmss", CultureInfo.InvariantCulture);
    
    // convert string to DateTime
    if(value.Length != 14)
        throw new ArgumentException("Value must be 14 characters.");
    int year = Int32.Parse(value.Substring(0, 4));
    int month = Int32.Parse(value.Substring(4,2));
    int day = Int32.Parse(value.Substring(6,2));
    int hour = Int32.Parse(value.Substring(8,2));
    int minute = Int32.Parse(value.Substring(10,2));
    int second = Int32.Parse(value.Substring(12,2));
    return new DateTime(year, month, day, hour, minute, second, 0);
