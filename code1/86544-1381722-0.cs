static void Main()
{
    string x = "abcdef";
    if (x.Length > 3)
    {
        if (!Char.IsWhiteSpace(x[3]))
            x = x.Insert(3, "-&lt;br />");
        else
            x = x.Insert(3, "&lt;br />");
    }
    Console.WriteLine(x);
}
