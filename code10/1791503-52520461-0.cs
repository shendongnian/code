    string[] words = { "0B", "00", " 00", "00", "00", "07", "3F", "14", "1D" };
    var words64 = new List<string>();
    int wc = 0;
    var s = string.Empty;
    var results = new List<ulong>();
    // Concat string to make 64 bit words
    foreach (var word in words) 
    {
        // remove extra whitespace
        s += word.Trim();
        wc++;
        
        // Added the word when it's 64 bits
        if (wc % 4 == 0)
        {
            words64.Add(s);
            wc = 0;
            s = string.Empty;
        }
    }
    // If there are any leftover bits, append those
    if (!string.IsNullOrEmpty(s))
    {
        words64.Add(s);
    }
    // Now attempt to convert each string to a ulong
    foreach (var word in words64)
    {
        ulong r;
        if (ulong.TryParse(word, 
            System.Globalization.NumberStyles.AllowHexSpecifier, 
            System.Globalization.CultureInfo.InvariantCulture, 
            out r))
        {
            results.Add(r);
        }
    }
