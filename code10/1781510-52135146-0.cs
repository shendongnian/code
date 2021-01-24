    public static int? _Points;
    public static string Points { get => GetPoints(); set => SetPoints(value); }
    public static string GetPoints()
    {
        if (_Points.HasValue)
        {
            return _Points.Value.ToString();
        }
        else
            return "";
    }
    public static void SetPoints(string value)
    {
        if (_Points.HasValue)
        {
            _Points = (_Points.Value + int.Parse(value));
        }
        else
            _Points = int.Parse(value);
    }
