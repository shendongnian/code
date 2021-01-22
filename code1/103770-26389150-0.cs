    private static readonly Regex regexKorean = new Regex(@"[가-힣]");
    public static bool IsKorean(this char s)
    {
        return regexKorean.IsMatch(s.ToString());
    }
    if (someText.Any(z => z.IsKorean()))
    {
        DoSomething();
    }
