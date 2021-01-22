    using System.Text.RegularExpressions
    ...
    char[] alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
    string contents = String.Empty;
    using (var file = new StreamReader("MyFile.txt"))
    {
         contents = file.ReadToEnd();
    }
    foreach (var c in alpha)
    {
        Match m = new Regex(c.ToString(), RegexOptions.IgnoreCase).Match(contents);
        if (m != null)
        {
            var str = m.Value;
        }
    }
