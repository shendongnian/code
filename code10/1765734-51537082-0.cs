    public const string Format = "yyyy.MM.dd hh:mm:ss:ffff";
    public DateTime ExtractDateTime(string log)
    {
        var regex = new Regex(@"\d{4}.\d{2}.\d{2} \d{2}.\d{2}.\d{2}.\d{4}");
        var match = regex.Match(log);
        return match.Success ? DateTime.ParseExact(match.Value, Format, null) : new DateTime();
    }
