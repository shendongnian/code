    var encoding = Encoding.GetEncoding(Encoding.ASCII.CodePage, 
        EncoderFallback.ExceptionFallback, 
        DecoderFallback.ExceptionFallback);
    var bracketRegex = new Regex(@"\[(?<digits>\d+)\]", RegexOptions.Compiled);
    MatchEvaluator convertToCodepoint = (match) => 
        Char.ConvertFromUtf32(Int32.Parse(match.Groups["digits"].Value));
    var values = new[] {"a", "b", "c" };
    var input = "[2] Test {1} {2} [3]";
    encoding.GetBytes(String.Format(bracketRegex.Replace(input, convertToCodepoint), values))
        .Dump();
