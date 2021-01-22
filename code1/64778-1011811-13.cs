    public static IEnumerable<string> GetExcelColumns(string alphabet)
    {
        int length = 0;
        char[] chars = null;
        int[] indexes = null;
        while (true)
        {
            int position = length-1;
            // Try to increment the least significant
            // value.
            while (position >= 0)
            {
                indexes[position]++;
                if (indexes[position] == alphabet.Length)
                {
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
            // If we got all the way to the start of the array,
            // we need an extra value
            if (position == -1)
            {
                length++; 
                chars = new char[length];
                indexes = new int[length];
                for (int i=0; i < length; i++)
                {
                    chars[i] = alphabet[0];
                }
            }
            yield return new string(chars);
        }
    }
