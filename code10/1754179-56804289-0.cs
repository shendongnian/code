    ...
    crypt(Encoding.UTF8.GetBytes("MyPassword").AddZeros());
    ...
    
    private static IEnumerable<byte> AddZeros(this IEnumerable<byte> pass)
    {
        foreach (var b in pass)
        {
            yield return b;
            yield return 0;
        }
    
        yield return 0;
        yield return 0;
    }
