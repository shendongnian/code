    string name = "tru\\e.jpg";
    char[] invalidChars = System.IO.Path.GetInvalidFileNameChars();
    string invalidString = Regex.Escape(new string(invalidChars));
    string valid = Regex.Replace(name, "[" + invalidString + "]", "");
    Console.WriteLine(valid);
