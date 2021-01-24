    var code = ...
    var stringLiterals = new Regex("\"[^\"\\\\]*(?:\\\\.[^\"\\\\]*)*\"", RegexOptions.Compiled);
    var multilineComments = new Regex("/\\*.*?\\*/", RegexOptions.Compiled | RegexOptions.Singleline);
    var singlelineComments = new Regex("//.*$", RegexOptions.Compiled | RegexOptions.Multiline);
    var @enum = new Regex("enum\\s*\\w+\\s*{.*?}", RegexOptions.Compiled | RegexOptions.Singleline);
    code = stringLiterals.Replace(code, m => "\"\"");
    code = multilineComments.Replace(code, m => "");
    code = singlelineComments.Replace(code, m => "");
    var enums = @enum.Matches(code).Cast<Match>().ToArray();
    foreach (var match in enums)
        Console.WriteLine(match.Value);
