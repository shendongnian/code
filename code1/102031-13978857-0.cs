    var results = new ConcurrentBag<int> ();
    Parallel.For (0, 10, set => {
        var encoding = Encoding.GetEncoding ("ISO-8859-1");
        var c = encoding.GetEncoder ();
        c.Fallback = new EncoderExceptionFallback ();
        var start = set * 1000;
        var end = start + 1000;
        Console.WriteLine ("Worker #{0}: {1} - {2}", set, start, end);
    
        char[] input = new char[1];
        byte[] output = new byte[5];
        for (int i = start; i < end; i++) {
            try {
                input[0] = (char)i;
                c.GetBytes (input, 0, 1, output, 0, true);
                results.Add (i);
            }
            catch {
            }
        }
    });
    var hashSet = new HashSet<int> (results);
    //hashSet.Remove ((int)'\r');
    //hashSet.Remove ((int)'\n');
    var sorted = hashSet.ToArray ();
    Array.Sort (sorted);
    var charset = new string (sorted.Select (i => (char)i).ToArray ());
