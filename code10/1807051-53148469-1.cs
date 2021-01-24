    var keys = hs.Keys.Cast<string>().ToArray();
    var values = hs.Values.Cast<string>().ToArray();
    
    for (var n = 0; n <= hs.Values.Count - 1; n++)
    {
        cm.Parameters.AddWithValue(keys[n], values[n]);
    }
