    public static string[] Slices(string numbers, int sliceLength)
    {
        int digits = numbers.Length;
        if (digits < sliceLength || sliceLength < 1)
            throw new ArgumentException();
        else
        {
            List<string> result = new List<string>();
            for(int x = 0; x < numbers.Length - 1; x++)
                result.Add(numbers.Substring(x, sliceLength));
            return result.ToArray();
        }
    }
