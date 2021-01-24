    public static string VowelsToSymbol(string input)
    {
        if (string.IsNullOrWhiteSpace(input)) return input;
        var work = new char[input.Length];
        for (int i = 0; i < work.Length; i++)
        {
            var c = input[i];
            switch (c)
            {
                case 'A': case 'E': case 'I': case 'O': case 'U':
                case 'a': case 'e': case 'i': case 'o': case 'u':
                    work[i] = '$'; break;
                default:
                    work[i] = c; break;
            }
        }
        return new string(work);
    }
