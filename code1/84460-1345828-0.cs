    var sb = new StringBuilder("GET THE HEX LINE SOME WAY");
    var strs = new string[sb.Length/2];
    var i = 0;
    var j = 0;
    while(i<sb.Length)
    {
        strs[j] = sb.ToString(i, 2);
        i += 2;
        j++;
    }
    foreach (var s in strs)
    {
        Console.WriteLine("Hex: {0}, Orig ASCII:  {1}",
                             s, Int32.Parse(s,NumberStyles.HexNumber));
    }
