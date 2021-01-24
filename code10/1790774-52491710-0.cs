    public class BytesInfo
    {
        public int Position { get; set; }
        public string Bytes { get; set; }
    }
    var source = @"C86B0200554E0200C86B02000000000000000000270000008109000000000000EC6A050079750188810000004100002801000000000000000000010000020104000000000000000000000000000000000000000000000000F65FA45900000000FF0000002F0000000000000049000000403C9F5A000000000000000000000000FFFF330000000000000F06EAE8333536";
    var l = new List<BytesInfo>();
    var p = 0;
    var s = "";
    for (var i = 0; i < source.Length; i += 2)
    {
        var b = source.Substring(i, 2);
        if (b == "00")
        {
            if (s != "")
            {
                l.Add(new BytesInfo()
                {
                    Position = p,
                    Bytes = s
                });
                s = "";
            }
        }
        else
        {
            if (s == "")
            {
                p = i;
            }
            s += b;
        }
    }
    foreach (var e in l)
    {
        Console.WriteLine($"Position: {e.Position}, Bytes: {e.Bytes}");
    }
