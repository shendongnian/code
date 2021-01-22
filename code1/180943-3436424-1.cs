    string input = "01110100011001010111001101110100";
    var bytesAsStrings =
        input.Select((c, i) => new { Char = c, Index = i })
             .GroupBy(x => x.Index / 8)
             .Select(g => new string(g.Select(x => x.Char).ToArray()));
    byte[] bytes = bytesAsStrings.Select(s => Convert.ToByte(s, 2)).ToArray();
    File.WriteAllBytes(fileName, bytes);
