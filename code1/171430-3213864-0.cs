    public void Sanitizer(List<string> paths)
    {
        string regPattern = (@"[~#&$!%+{}]+");
        string replacement = " ";
        Regex regExPattern = new Regex(regPattern);
        Regex regExPattern2 = new Regex(@"\s{2,}");
