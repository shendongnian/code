public static void Main()
{
    Console.Out.WriteLine(Format("")); // no entries
    Console.Out.WriteLine(Format(".jpg"));  // one entry
    Console.Out.WriteLine(Format(".jpg|.gif")); // two entries
    Console.Out.WriteLine(Format(".jpg|.gif|.png")); // three entries
    Console.In.ReadLine();
}
private static string Format(string extensionsText)
{
    string[] extensions = extensionsText.Split('|');
    if (extensions[0] == string.Empty) return "No formats are allowed";
    if (extensions.Length == 1) return string.Format("Allowed format is \"{0}\".", extensions[0]);
    var message = new StringBuilder("Allowed formats are ");
    // first entry
    message.Append('"').Append(extensions[0]).Append('"');
    // middle entries
    for (int index = 1; index &lt; extensions.Length - 1; index += 1)
    {
        message.Append(", ");
        message.Append('"').Append(extensions[index]).Append('"');
    }
    // last entry
    message.Append(" and ");
    message.Append('"').Append(extensions[extensions.Length - 1]).Append('"');
    message.Append('.');
    return message.ToString();
}
