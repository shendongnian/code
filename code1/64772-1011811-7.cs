    public static IEnumerable<string> GetExcelColumns(string alphabet)
    {
        int length = 1;
        char[] chars = null;
        int[] indexes = null;
        while (true)
        {
            if (chars == null)
            {
                chars = new char[length];
                indexes = new int[length];
                for (int i=0; i < length; i++)
                {
                    chars[i] = alphabet[0];
                }
                // First string of this length is ready
                yield return new string(chars);
            }
            int position = length-1;
            while (true)
            {
                indexes[position]++;
                if (indexes[position] == alphabet.Length)
                {
                    if (position == 0)
                    {
                        // Need more space! Abort!
                        position = -1;
                        break;
                    }
                    for (int i=position; i < length; i++)
                    {
                        indexes[i] = 0;
                        chars[i] = alphabet[0];
                    }
                    position--;
                }
                else
                {
                    chars[position] = alphabet[indexes[position]];
                    break;
                }
            }
            if (position == -1)
            {
                length++;
                chars = null;
                continue;
            }
            yield return new string(chars);
        }
    }
