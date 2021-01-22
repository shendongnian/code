    using System.Text.RegularExpressions;
    using System.IO;
    ...
    char[] alpha = "abcdefjhijklmnopqrstuvwxyz".ToCharArray();
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
            // do something with str
        }
    }
