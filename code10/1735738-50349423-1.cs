    private int[] DecodeCharCode(string str) =>
        DecodeCharCode(str.ToArray());
    
    private int[] DecodeCharCode(char[] chars)
    {
        int[] result = new int[chars.Length];
        for (int i = 0; i < chars.Length; i++)
        {
            result[i] = (int)chars[i];
        }
        return result;
    }
