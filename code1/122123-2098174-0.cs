    string input = "<root><abc><deg><foo></abc><bar></root>";
    string pattern = @"(<(?<tag>\w+)>)(?!.*</\k<tag>>)";
    string result = Regex.Replace(input, pattern,
                             match => HttpUtility.HtmlEncode(match.Value));
    XDocument document = XDocument.Parse(result);
    Console.WriteLine(document.ToString());
