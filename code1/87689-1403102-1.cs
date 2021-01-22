    string name = ";;;'']][[ zion \\\\[[[]]]";
    char[] invalidChars = System.IO.Path.GetInvalidPathChars();
    string invalidString = Regex.Escape(new string(invalidChars));
    
    string valid = Regex.Replace(name, "[" + invalidString + "]", "");
    Console.WriteLine(valid);
