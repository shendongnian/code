    // Split the text box into lines
    var lines = text.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
    var finalText = string.Empty;
    foreach (var line in lines)
    {
        var formattedLine = line;
                
        // Replace all characters that are not a digit by a space
        var charsToReplace = line.ToCharArray().Where(x => !char.IsDigit(x)).Distinct();
        foreach (var charToReplace in charsToReplace)
        {
            formattedLine = line.Replace(charToReplace, ' ');
        }
        // Replace multiple spaces by single space
        formattedLine = new Regex("[ ]{2,}").Replace(formattedLine, " ").Trim();
        // Split the line at every space, and cast the result to an int
        var intEnumerable = formattedLine.Split(' ').Select(x => int.Parse(x.Trim()));
        // Order the list ascending or descending
        //var orderedListDescending = intEnumerable.OrderByDescending(x => x);
        var orderedList = intEnumerable.OrderBy(x => x);
        // Concatenate each ordered line in a string variable, separated by Environment.NewLine
        finalText += string.Join(" ", orderedList) + Environment.NewLine;
    }
