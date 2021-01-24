    // Replace all characters that are not a digit by a space
    var charsToReplace = text.ToCharArray().Where(x => !char.IsDigit(x)).Distinct();
    foreach (var charToReplace in charsToReplace)
    {
        text = text.Replace(charToReplace, ' ');
    }
    // Replace multiple spaces by single space
    text = new Regex("[ ]{2,}").Replace(text, " ");
    // Split the line at every space, and cast the result to an int
    var intEnumerable = text.Split(' ').Select(x => int.Parse(x.Trim()));
    // Order the list ascending or descending
    //var orderedListDescending = intEnumerable.OrderByDescending(x => x);
    var orderedList = intEnumerable.OrderBy(x => x);
    // If you want to have it as a string to put in another text box or in a file
    var concatenatedInt = string.Join(" ", orderedList);
