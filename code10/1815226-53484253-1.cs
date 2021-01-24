    string[] lines = File.ReadAllLines(fd, Encoding.GetEncoding(1257));
    int maxLength = lines.Max(l => l.Length);
    lines = lines.Select(l => l.Justify(maxLength)).ToArray();
    public static string Justify(this string input, int length)
    {
        string[] words = input.Split(' ');
        if (words.Length == 1)
        {
            return input.PadRight(length);
        }
        string output = string.Join(" ", words);
        while (output.Length < length)
        {
            for (int w = 0; w < words.Length - 1; w++)
            {
                words[w] += " ";
                output = string.Join(" ", words);
                if (output.Length == length)
                {
                    break;
                }
            }
        }
        return output;
    }
