    private static string NormalizeWhitespace(string test)
    {
        string trimemd = test.Trim();
    
        var sb = new StringBuilder(test.Length);
    
        int i = 0;
        while (i < test.Length)
        {
            if (test[i] == ' ')
            {
                sb.Append(test[i]);
    
                do { i++; } while (i < test.Length && test[i] == ' ');
            }
    
            sb.Append(test[i]);
    
            i++;
        }
    
        return sb.ToString();
    }
