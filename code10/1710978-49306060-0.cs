    static DateTime ToDt(string date)
    {
        var splitYear = date.Split(new[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
        var splitDays = splitYear[1].Split(new[] { 'T' }, StringSplitOptions.RemoveEmptyEntries);
        var hms = splitDays[1].TrimEnd('Z').Split(':');
        var dt = new DateTime(int.Parse(splitYear[0]), 1, 1, 0, 0, 0);
        dt = dt.AddDays(int.Parse(splitDays[0]) - 1);
        dt = dt.AddHours(int.Parse(hms[0]));
        dt = dt.AddMinutes(int.Parse(hms[1]));
        dt = dt.AddSeconds(int.Parse(hms[2]));
        return dt;
    }
    static void Main(string[] args)
    {
        Console.WriteLine(ToDt("1900-001T00:10:00Z"));
        Console.WriteLine(ToDt("1923-180T12:11:10Z"));
        Console.WriteLine(ToDt("1979-365T23:59:59Z"));
        Console.WriteLine(ToDt("2017-074T18:47:10Z"));
        Console.ReadLine();
    }
