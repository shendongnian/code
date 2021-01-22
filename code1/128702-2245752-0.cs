    string input = "45.690 24.1023 .09223 4.1334";
    string pattern = "\s*";            // Split on whitepsace
    
    string[] substrings = Regex.Split(input, pattern);
    foreach (string match in substrings)
    {
       Console.WriteLine("'{0}'", match);
    }
