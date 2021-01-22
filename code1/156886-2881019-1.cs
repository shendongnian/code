    // DataToken = {[foo]}
    // FieldToken = {Bar}
    string pattern = @"(?<DataToken>\{\[\w+\]\})|(?<FieldToken>\{\w+\})";
    MatchCollection matches = Regex.Matches(expression.ExpressionString, pattern,
    RegexOptions.ExplicitCapture);
    string fieldToken = string.Empty;
    string dataToken = string.Empty;
    foreach (Match m in matches)
    {
        // note that EITHER fieldtoken OR DataToken will have a value in each loop
        fieldToken = m.Groups["FieldToken"].Value;
        dataToken = m.Groups["DataToken"].Value;
        if (!string.IsNullOrEmpty(dataToken))
        {
             // Do something
        }
        if (!string.IsNullOrEmpty(fieldToken))
        {
             // Do something else
       }
    }
