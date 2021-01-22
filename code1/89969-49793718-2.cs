    static IEnumerable<byte[]> Iterate(int arrayLength) {
        var arr = new byte[arrayLength];
        var i = 0;
        yield return arr;
        while (i < arrayLength)
        {
            if (++arr[i] != 0)
            {
                i = 0;
                yield return arr;
            }
            else i++;
        }
    }
    
    static void Main(string[] args)
    {
        foreach (var arr in Iterate(2))
        {
            Console.Write(String.Join(",", arr.Select(x => $"{x:D3}")));
            Console.WriteLine();
        }
    }
