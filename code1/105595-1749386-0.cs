    string allowed =
        "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
    // take characters from the original until we find one that's not in "allowed"
    string clean = new string(original.TakeWhile(allowed.Contains).ToArray());
    // the bad characters are whatever is left of the original string
    string bad = original.Substring(clean.Length);
    if (bad.Length > 0)
    {
        // log bad characters somewhere
    }
    Console.WriteLine(clean);
