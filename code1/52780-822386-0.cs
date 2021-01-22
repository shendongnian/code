    public static string ProcessBackspaces(string source)
    {
        char[] buffer = new char[source.Length];
        int idx = 0;
        foreach (char c in source)
        {
            if ((c == '\b') && (idx > 0))
            {
                idx--;
            }
            else
            {
                buffer[idx] = c;
                idx++;
            }
        }
        return new string(buffer, 0, idx);
    }
    // ...
    string test1 = "\b\bfoo\bx";
    Console.WriteLine(ProcessBackspaces(test1));    // fox
    string test2 = "patt\b\b\b\b\b\b\b\b\b\bfoo";
    Console.WriteLine(ProcessBackspaces(test2));    // foo
