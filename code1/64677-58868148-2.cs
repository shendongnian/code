public static string Format(this string formatString, string[,] nameValuePairs)
{
    if (nameValuePairs.GetLength(1) != 2)
    {
        throw new ArgumentException("Name value pairs array must be [N,2]", nameof(nameValuePairs));
    }
    StringBuilder newFormat = new StringBuilder(formatString);
    int count = nameValuePairs.GetLength(0);
    object[] values = new object[count];
    for (var index = 0; index < count; index++)
    {
        newFormat = newFormat.Replace(string.Concat("{", nameValuePairs[index,0], "}"), string.Concat("{", index.ToString(), "}"));
        values[index] = nameValuePairs[index,1];
    }
    return string.Format(newFormat.ToString(), values);
}
Call the above with:
string format = "{foo} = {bar} (really, it's {bar})";
string formatted = format.Format(new[,] { { "foo", "Dictionary" }, { "bar", "unnecessary" } });
Results in: `"Dictionary = unnecessary (really, it's unnecessary)"`
