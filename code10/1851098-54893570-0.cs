    public static void Main(string[] args)
    {
        string dnumber = Str();
        string[] array = dnumber.Split(',', StringSplitOptions.RemoveEmptyEntries);
        int[] v1 = Array.ConvertAll(array, s => int.Parse(s));
        int[] v2 = Array.ConvertAll(array, int.Parse);
        int[] v3 = array.Select(int.Parse).ToArray();
    }
